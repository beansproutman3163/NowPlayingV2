using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Newtonsoft.Json;
using NowPlayingCore.Core;
using NowPlayingCore.Misskey.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Windows;
using System.Windows.Media.Imaging;


namespace NowPlayingV2.UI
{
	/// <summary>
	/// MisskeyAuthWindow.xaml の相互作用ロジック
	/// </summary>
	public partial class MisskeyAuthWindow : MetroWindow
    {
        static readonly HttpClient client = new HttpClient();

        string hostName = "";
        string sessionId = "";

        public MisskeyAuthWindow()
        {
            InitializeComponent();
            panelSavedAccount.Visibility = Visibility.Hidden;
		}

        private async void OnOpenMiAuthPageAsync(object sender, RoutedEventArgs e)
        {
			var progdiag = await this.ShowProgressAsync("読み込み中...", "認証の準備をしています。しばらくお待ちください。");
			try
			{
                this.sessionId = Guid.NewGuid().ToString();
                this.hostName = InstanceNameTextBox.Text;
				
                var appName = "なうぷれTunes";

				var info = new ProcessStartInfo() {
                    FileName = $"https://{this.hostName}/miauth/{this.sessionId}?name={appName}",
                    UseShellExecute = true
                };
                Process.Start(info);

				WindowTab.SelectedIndex = 1;
			}
			catch (System.ComponentModel.Win32Exception noBrowser) {
				if (noBrowser.ErrorCode == -2147467259) {
					await this.ShowMessageAsync("エラー",
                        $"お使いのPCでブラウザの確認ができませんでした。インストールされてるか確認してくださいまし。\n\n{noBrowser}");
				}
			}
			catch (Exception ex)
            {
                await this.ShowMessageAsync("エラー",
                    $"何らかのエラーで認証を開始することが出来ませんでした。サーバー名をもう一度確認してください。\n\n{ex}");
            }
            finally
            {
                await progdiag.CloseAsync();
            }
        }

        private async void OnGetAccountAsync(object sender, RoutedEventArgs e)
        {
            var progdiag = await this.ShowProgressAsync("読み込み中...", "認証の準備をしています。しばらくお待ちください。");
            try
            {
                var req = new HttpRequestMessage() {
                    Method = HttpMethod.Post,
                    RequestUri = new Uri($"https://{this.hostName}/api/miauth/{this.sessionId}/check"),
                };
                var res = await client.SendAsync(req);

                if (!res.IsSuccessStatusCode) {
                    await this.ShowMessageAsync("通信エラー",
                        $"認証リクエストに失敗しました。\n\n{res.StatusCode} : {res.ReasonPhrase}");
                    return;
                }
                
				var resAuth = JsonConvert.DeserializeObject<AuthCheckResponse>(await res.Content.ReadAsStringAsync());
				if (!resAuth.Ok) {
					await this.ShowMessageAsync("エラー",
						$"認証が許可されませんでした。\nお使いのMisskeyアカウントで「なうぷれV2」のアプリケーション認証が許可されているかご確認ください。");
					return;
				}

                UserDetailed user = resAuth.User!;
				this.panelSavedAccount.DataContext = new {
					DisplayName = user.Name,
					UserName = $"@{user.UserName}@{this.hostName}",
					Notes = user.NotesCount,
					Following = user.FollowingCount,
					Followers = user.FollowersCount
				};
                if (user.AvatarUrl != null) {

                    var avatarUriWebp = new Uri(user.AvatarUrl);
                    var queryParams = new Dictionary<string, string>();
                    foreach (var query in avatarUriWebp.Query[1..].Split('&')) {
                        var kv = query.Split('=');
                        if (kv.Length == 2) {
                            queryParams.Add(kv[0], kv[1]);
						}
                    }
					
					if (queryParams.TryGetValue("url", out string? avatarUrl)) {
						var reqGetAvatar = new HttpRequestMessage() {
							RequestUri = new Uri(System.Web.HttpUtility.UrlDecode(avatarUrl)),
							Method = HttpMethod.Get
						};
                        
						var resGetAvatar = await client.SendAsync(reqGetAvatar);
						if (resGetAvatar.IsSuccessStatusCode) {
							using var stream = await resGetAvatar.Content.ReadAsStreamAsync();
							var decoder = new JpegBitmapDecoder(stream, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
							
							if (stream != null) {
								this.imgAccountIcon.Source = decoder.Frames[0];
							}
						}
					}
                }

				var container = new MisskeyAccount(new MisskeyAccountInfo() {
                    UserName = user.UserName,
                    HostName = this.hostName,
                    DisplayName = user.Name ?? "",
                    Token = resAuth.Token!
                });
				await container.UpdateCache();
				Core.ConfigStore.StaticConfig.accountList.Add(container);

				this.panelSavedAccount.Visibility = Visibility.Visible;
			}
            catch (HttpRequestException ex) {
				await this.ShowMessageAsync("ネットワークエラー",
					$"通信に失敗しました。ネットワーク接続を確認後、再度お試しください。\n\n{ex}");
			}
            catch (Exception ex)
            {
                await this.ShowMessageAsync("エラー",
                    $"何らかのエラーで認証を開始することが出来ませんでした。\n\n{ex}");
            }
            finally
            {
                await progdiag.CloseAsync();
            }
        }
	}
}