﻿using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using MahApps.Metro.Controls.Dialogs;
using NowPlayingCore.Core;
using NowPlayingCore.NowPlaying;
using NowPlayingV2.Core;
using NowPlayingV2.Matsuri;
using NowPlayingV2.UI.Theme;
using NowPlayingV2.UI.View;

namespace NowPlayingV2.UI
{
    public partial class MainWindow
    {
        private static MainWindow? windowInstance;
        private Model4SongView? songView;

        public static void OpenSingletonWindow()
        {
            if (windowInstance == null)
            {
                (new MainWindow()).Show();
            }
            else
            {
                windowInstance.Activate();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = ConfigStore.StaticConfig;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (PipeListener.StaticPipeListener == null)
            {
                throw new InvalidOperationException(
                    "PipeListener.StaticPipeListener must be initialized before calling this method.");
            }

            windowInstance = this;
            BindingOperations.EnableCollectionSynchronization(ConfigStore.StaticConfig.accountList, new object());
            PipeListener.StaticPipeListener.OnMusicPlay += UpdatePlayingSongView;
            if (PipeListener.StaticPipeListener.LastPlayedSong != null)
            {
                UpdatePlayingSongView(PipeListener.StaticPipeListener.LastPlayedSong);
            }

            if (ConfigStore.StaticConfig.HintDiagClosed)
            {
                HintBoxGrid.Visibility = Visibility.Hidden;
            }
        }

        private void UpdatePlayingSongView(SongInfo songInfo)
        {
            songView = new Model4SongView(songInfo);
            Dispatcher.Invoke(() =>
            {
                (new FrameworkElement[] {SongImage, SongTitleLabel, SongAlbumLabel, SongArtistLabel}).ToList().ForEach(
                    i => { i.DataContext = songView; });
                NothingPlayingGrid.Visibility = Visibility.Hidden;
            });
        }

        private void OnAddAccountClick(object sender, RoutedEventArgs e)
        {
            (new UI.OAuthWindow()).ShowDialog();
        }

        private async void OnUpdateAccountClick(object sender, RoutedEventArgs e)
        {
            var res = await this.ShowMessageAsync("アカウント情報を更新しますか？", "アカウントの名前やIDの情報を再取得しますか？",
                MessageDialogStyle.AffirmativeAndNegative);
            if (res != MessageDialogResult.Affirmative) return;
            var waitdiag = await this.ShowProgressAsync("アカウント情報を取得中...", "アカウント情報を取得しています。しばらくお待ちください。");
            try
            {
                await AccountManager.UpdateAccountAsync(ConfigStore.StaticConfig.accountList);
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("エラー", $"正常にアカウント情報を更新出来ませんでした。\n\n{ex.Message}\n{ex.StackTrace}",
                    MessageDialogStyle.AffirmativeAndNegative);
            }
            finally
            {
                await waitdiag.CloseAsync();
            }

            ConfigStore.StaticConfig.accountList.ToList().ForEach(itm => itm.ReDrawAllProperty());
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (PipeListener.StaticPipeListener == null)
            {
                throw new InvalidOperationException(
                    "PipeListener.StaticPipeListener must be initialized before calling this method.");
            }

            PipeListener.StaticPipeListener.OnMusicPlay -= UpdatePlayingSongView;
            windowInstance = null;
            ConfigStore.SaveConfig(ConfigStore.StaticConfig);
        }

        private void ThemeSelector_Changed(object sender, SelectionChangedEventArgs e)
        {
            ((sender as ComboBox)?.SelectedItem as NPTheme)?.ApplyTheme();
        }

        private void OnAddMastodonAccountClick(object sender, RoutedEventArgs e)
        {
            (new UI.MastodonOAuthWindow()).ShowDialog();
        }

        private void OnAddMisskeyAccountClick(object sender, RoutedEventArgs e)
        {
            (new UI.MisskeyAuthWindow()).ShowDialog();
        }

        private void HintOKButton(object sender, RoutedEventArgs e)
        {
            HintBoxGrid.Visibility = Visibility.Hidden;
            ConfigStore.StaticConfig.HintDiagClosed = true;
        }
    }
}