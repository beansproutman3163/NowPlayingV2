﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NowPlayingCore.Core;

namespace NowPlayingCore.NowPlaying
{
    public class AutoTweet
    {
        private ConfigBase appconfig;
        private Task tweetTask;
        private AutoResetEvent resetevent = new AutoResetEvent(false);
        private CancellationTokenSource cancellationToken = new CancellationTokenSource();
        private SongInfo lastplayedsong;
        private DateTime lasttweettime;
        private PipeListener pipelistener;
        private static AutoTweet singletonautoTweet;

        public static AutoTweet AutoTweetSingleton => singletonautoTweet ?? (singletonautoTweet = new AutoTweet());
        public bool isInitialized = false;

        public void InitListner(PipeListener pl, ConfigBase cb)
        {
            if (appconfig != null) throw new Exception("DO NOT RE-INITIALIZE.");
            pipelistener = pl;
            pipelistener.OnMusicPlay += OnMusicPlay;
            appconfig = cb;
            isInitialized = true;
        }

        public void UnInitListner()
        {
            pipelistener.OnMusicPlay -= OnMusicPlay;
            appconfig = null;
            isInitialized = false;
        }

        private void OnMusicPlay(SongInfo songInfo)
        {
            Task.Run(async () =>
            {
                if (!appconfig.EnableAutoTweet) return;
                if (appconfig.EnablePostDelay && !(tweetTask?.IsCompleted ?? true))
                {
                    //cancel tweet job
                    Trace.WriteLine($"[AutoTweet PostDelay]Cancel tweet task start.");
                    cancellationToken.Cancel();
                    resetevent.Set();
                    await tweetTask;
                    Trace.WriteLine($"[AutoTweet PostDelay]Cancel tweet task OK.");
                }

                //can't reuse this
                cancellationToken = new CancellationTokenSource();
                //start task
                tweetTask = Task.Run(() =>
                {
                    try
                    {
                        //check for album art
                        var enableAlbumArt = appconfig.EnableTweetWithAlbumArt;
                        if (appconfig.EnableNoAlbumArtworkOnSameAlbum)
                        {
                            if (songInfo.Album == lastplayedsong?.Album)
                            {
                                Trace.WriteLine($"[AutoTweet]Disabled album art tweet.(reason=same album)");
                                enableAlbumArt = false;
                            }
                        }

                        //same album check
                        if (appconfig.EnableNoTweetOnSameAlbum)
                        {
                            if (songInfo.Album == lastplayedsong?.Album)
                            {
                                Trace.WriteLine($"[AutoTweet]Canceled tweet.(reason=EnableNoTweetOnSameAlbum)");
                                return;
                            }
                        }

                        //post delay
                        if (appconfig.EnablePostDelay)
                        {
                            Trace.WriteLine(
                                $"[AutoTweet PostDelay]Waiting for {appconfig.PostDelaySecond * 1000}msec.");
                            resetevent.WaitOne(appconfig.PostDelaySecond * 1000);
                        }

                        //post delay(by last tweet time)
                        if (appconfig.EnableTimePostDelay)
                        {
                            if (lasttweettime != default(DateTime))
                            {
                                if (!(DateTime.Now - lasttweettime >=
                                      new TimeSpan(0, 0, appconfig.TimePostDelayMin, appconfig.TimePostDelaySec)))
                                {
                                    Trace.WriteLine($"[AutoTweet]Canceled tweet.(reason=EnableTimePostDelay)");
                                    return;
                                }
                            }
                        }

                        cancellationToken.Token.ThrowIfCancellationRequested();
                        lastplayedsong = (SongInfo) songInfo.Clone();
                        lasttweettime = DateTime.Now;

                        //tweet it!
                        try
                        {
                            //get account list(only enabled)
                            appconfig.accountList.Where(itm => itm.Enabled).ToList().ForEach(async (accCont) =>
                            {
                                //make tweet string
                                var tweetText = Tsumugi.TweetConverter.SongInfoToString(appconfig.TweetFormat,
                                    songInfo,
                                    appconfig.EnableAutoDeleteText140, accCont);
                                if (accCont.CountText(tweetText) > accCont.MaxTweetLength)
                                    throw new Exception(
                                        $"[AutoTweet]Tweet text was over {accCont.MaxTweetLength} chars.");
                                //tweet
                                if (enableAlbumArt && songInfo.IsAlbumArtAvaliable())
                                {
                                    if (accCont is MastodonAccount mastodonAccount)
                                    {
                                        await mastodonAccount.UpdateStatus(tweetText, songInfo.AlbumArtBase64,
                                            appconfig.MastodonTootVisibility);
                                    }
                                    else
                                    {
                                        await accCont.UpdateStatus(tweetText, songInfo.AlbumArtBase64);
                                    }
                                }
                                else
                                {
                                    if (accCont is MastodonAccount mastodonAccount)
                                    {
                                        await mastodonAccount.UpdateStatus(tweetText, appconfig.MastodonTootVisibility);
                                    }
                                    else
                                    {
                                        await accCont.UpdateStatus(tweetText);
                                    }
                                }

                                Trace.WriteLine($"[AutoTweet]Sent tweet for account @{accCont.ID}.");
                            });
                        }
                        catch (Exception ex)
                        {
                            Trace.WriteLine($"[AutoTweet]Tweet error.\n{ex.Message}");
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        Trace.WriteLine($"[AutoTweet] OperationCanceledException");
                    }
                    catch (Exception ex)
                    {
                        Trace.WriteLine($"[AutoTweet] {ex.Message}");
                    }
                });
            });
        }

        public void StopAllTask()
        {
            cancellationToken.Cancel();
            resetevent.Set();
        }
    }
}