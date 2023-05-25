using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class User
	{
		public string Id { get; } = null!;
		public string? Name { get; } = null!;
		public string UserName { get; } = null!;
		public string? Host { get; } = null!;
		public string? AvatarUrl { get; } = null!;
		public string? AvatarBlurhash { get; } = null!;
		public bool IsBot { get; }
		public bool IsCat { get; }
		public Instance? Instance { get; }
		public Dictionary<string, string> Emojis { get; } = null!;
		public string OnlineStatus { get; } = null!;
		public BadgeRole[]? BadgeRoles { get; }
	}
}
