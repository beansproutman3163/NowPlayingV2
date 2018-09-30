﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastonet;

namespace NowPlayingCore.Core
{
    public class ConfigBase
    {
        public ObservableCollection<AccountContainer> accountList = new ObservableCollection<AccountContainer>();
        public bool CheckUpdate { get; set; } = true;
        public bool EnableAutoTweet { get; set; } = false;
        public bool EnablePostDelay { get; set; } = false;
        public bool EnableTimePostDelay { get; set; } = false;
        public int PostDelaySecond { get; set; } = 30;
        public int TimePostDelayMin { get; set; } = 5;
        public int TimePostDelaySec { get; set; } = 0;
        public bool EnableTweetWithAlbumArt { get; set; } = false;
        public bool EnableNoAlbumArtworkOnSameAlbum { get; set; } = false;
        public bool EnableNoTweetOnSameAlbum { get; set; } = false;
        public bool EnableAutoDeleteText140 { get; set; } = false;
        public bool EnableITunesPlugin { get; set; } = false;
        public bool HintDiagClosed { get; set; } = false;
        public string TweetFormat { get; set; } = "Nowplaying $Title - $Artist #NowPlaying";
        public Visibility MastodonTootVisibility { get; set; } = Visibility.Public;
    }
}