using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Security;
using System.Text;
using Newtonsoft.Json;
using NowPlayingCore.Misskey.Entities;

namespace NowPlayingCore.Misskey
{
	internal class MiAuthClient
	{
		private readonly static HttpClient client = new HttpClient();

		private string hostName;
		private string sessionId;

		public MiAuthClient(string hostName)
		{
			this.hostName = hostName;
			this.sessionId = Guid.NewGuid().ToString();
		}

		class MiAuthParam
		{
			public string? AppName { get; set; }
			public string? IconUrl { get; set; }
			public string? CallbackUrl { get; set; }
			public Permissions Permission { get; set; }

			private string query = "";

			private void AddQueryParam(string param)
			{
				if (this.query == "") {
					this.query = param;
				}
				else {
					this.query += "&" + param;
				}
			}

			public string ToQueryParam()
			{
				if (this.AppName == null && 
					this.IconUrl == null &&
					this.CallbackUrl == null &&
					this.Permission == Permissions.None) {
					return "";
				}

				if (this.AppName != null) {
					this.AddQueryParam(this.AppName);
				}
				if (this.IconUrl != null) {
					this.AddQueryParam(this.IconUrl);
				}
				if (this.CallbackUrl != null) {
					this.AddQueryParam(this.CallbackUrl);
				}
				if (this.Permission != Permissions.None) {
					this.AddQueryParam(this.GetPermissionString());
				}

				return "?" + query;
			}

			private string permissions = "";

			private void AddPermission(string permission)
			{
				if (this.permissions == "") {
					this.permissions = permission;
				}
				else {
					this.permissions += "," + permission;
				}
			}

			private string GetPermissionString()
			{
				if (this.Permission.HasFlag(Permissions.ReadAccount)) {
					this.AddPermission("read:account");
				}
				if (this.Permission.HasFlag(Permissions.WriteAccont)) {
					this.AddPermission("write:account");
				}
				if (this.Permission.HasFlag(Permissions.ReadBlocks)) {
					this.AddPermission("read:blocks");
				}
				if (this.Permission.HasFlag(Permissions.WriteBlocks)) {
					this.AddPermission("write:blocks");
				}
				if (this.Permission.HasFlag(Permissions.ReadDrive)) {
					this.AddPermission("read:drive");
				}
				if (this.Permission.HasFlag(Permissions.WriteDrive)) {
					this.AddPermission("write:drive");
				}
				if (this.Permission.HasFlag(Permissions.ReadFavorites)) {
					this.AddPermission("read:favorites");
				}
				if (this.Permission.HasFlag(Permissions.WriteFavorites)) {
					this.AddPermission("write:favorites");
				}
				if (this.Permission.HasFlag(Permissions.ReadFollowing)) {
					this.AddPermission("read:following");
				}
				if (this.Permission.HasFlag(Permissions.WriteFollowing)) {
					this.AddPermission("write:following");
				}
				if (this.Permission.HasFlag(Permissions.ReadMessaging)) {
					this.AddPermission("read:messaging");
				}
				if (this.Permission.HasFlag(Permissions.WriteMessaging)) {
					this.AddPermission("write:messaging");
				}
				if (this.Permission.HasFlag(Permissions.ReadMutes)) {
					this.AddPermission("read:mutes");
				}
				if (this.Permission.HasFlag(Permissions.WriteMutes)) {
					this.AddPermission("write:mutes");
				}
				if (this.Permission.HasFlag(Permissions.WriteNotes)) {
					this.AddPermission("write:notes");
				}
				if (this.Permission.HasFlag(Permissions.ReadNotifications)) {
					this.AddPermission("read:notifications");
				}
				if (this.Permission.HasFlag(Permissions.WriteNotifications)) {
					this.AddPermission("write:notifications");
				}
				if (this.Permission.HasFlag(Permissions.WriteReactions)) {
					this.AddPermission("write:reactions");
				}
				if (this.Permission.HasFlag(Permissions.WriteVotes)) {
					this.AddPermission("write:votes");
				}
				if (this.Permission.HasFlag(Permissions.ReadPages)) {
					this.AddPermission("read:pages");
				}
				if (this.Permission.HasFlag(Permissions.WritePages)) {
					this.AddPermission("write:pages");
				}
				if (this.Permission.HasFlag(Permissions.ReadPageLikes)) {
					this.AddPermission("read:page-likes");
				}
				if (this.Permission.HasFlag(Permissions.WritePageLikes)) {
					this.AddPermission("write:page-likes");
				}
				if (this.Permission.HasFlag(Permissions.ReadGalleryLikes)) {
					this.AddPermission("read:gallery-likes");
				}
				if (this.Permission.HasFlag(Permissions.WriteGalleryLikes)) {
					this.AddPermission("write:gallery-likes");
				}
				return this.permissions;
			}
		}

		[Flags]
		enum Permissions
		{
			None = 0,
			ReadAccount			= 1 << 1,
			WriteAccont			= 1 << 2,
			ReadBlocks			= 1 << 3,
			WriteBlocks			= 1 << 4,
			ReadDrive			= 1 << 5,
			WriteDrive			= 1 << 6,
			ReadFavorites		= 1 << 7,
			WriteFavorites		= 1 << 8,
			ReadFollowing		= 1 << 9,
			WriteFollowing		= 1 << 10,
			ReadMessaging		= 1 << 11,
			WriteMessaging		= 1 << 12,
			ReadMutes			= 1 << 13,
			WriteMutes			= 1 << 14,
			WriteNotes			= 1 << 15,
			ReadNotifications	= 1 << 16,
			WriteNotifications	= 1 << 17,
			WriteReactions		= 1 << 18,
			WriteVotes			= 1 << 19,
			ReadPages			= 1 << 20,
			WritePages			= 1 << 21,
			ReadPageLikes		= 1 << 22,
			WritePageLikes		= 1 << 23,
			ReadGalleryLikes	= 1 << 24,
			WriteGalleryLikes	= 1 << 25,
		}

		public void OpenMiAuthBrowser(MiAuthParam param)
		{
			var info = new ProcessStartInfo() {
				FileName = $"https://{this.hostName}/miauth/{this.sessionId}?name={param.AppName}",
				UseShellExecute = true
			};
			Process.Start(info);
		}

		public async AuthCheckResponse SendMiAuthCheck()
		{
			var req = new HttpRequestMessage() {
				Method = HttpMethod.Post,
				RequestUri = new Uri($"https://{this.hostName}/api/miauth/{this.sessionId}/check"),
			};
			var res = await client.SendAsync(req);

			if (!res.IsSuccessStatusCode) {
				
			}

			var resAuth = JsonConvert.DeserializeObject<AuthCheckResponse>(await res.Content.ReadAsStringAsync());
			if (!resAuth.Ok) {
				
			}

			return resAuth;
		}

		/*
		 * CallbackにカスタムURLスキームか何かを指定してこのアプリにリダイレクトさせたい
		 */
		// void OnReceiveCallback() { }
	}
}
