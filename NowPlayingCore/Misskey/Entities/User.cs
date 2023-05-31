using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class User
	{
		[JsonProperty] string id = null!;
		public string Id => id;

		[JsonProperty] string name = null!;
		public string? Name => name;

		[JsonProperty] string username = null!;
		public string UserName => username;

		[JsonProperty] string? host = null!;
		public string? Host => host;

		[JsonProperty] string? avatarUrl;
		public string? AvatarUrl => avatarUrl;

		[JsonProperty] string? avatarBlurhash;
		public string? AvatarBlurhash => avatarBlurhash;

		[JsonProperty] bool isBot;
		public bool IsBot => isBot;

		[JsonProperty] bool isCat;
		public bool IsCat => isCat;

		[JsonProperty] Instance? instance;
		public Instance? Instance => instance;

		[JsonProperty] Dictionary<string, string> emojis = null!;
		public Dictionary<string, string> Emojis => emojis;

		[JsonProperty] string onlineStatus = null!;
		public string OnlineStatus => onlineStatus;

		[JsonProperty] List<BadgeRole>? badgeRoles;
		public List<BadgeRole>? BadgeRoles => badgeRoles;

	}
}
