using CoreTweet;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class DriveFile
	{
		public string Id { get; } = null!;
		public string CreatedAt { get; } = null!;
		public string Name { get; } = null!;
		public string Type { get; } = null!;
		public string MD5 { get; } = null!;
		public int Size { get; }
		public bool IsSensitive { get; }
		public string BlurHash { get; } = null!;
		public class Property
		{
			public int Width { get; }
			public int Height { get; }
			public int Orientation { get; }
			public string? AvgColor { get; }
		}
		public Property Properties { get; } = null!;
		public string Url { get; } = null!;
		public string? ThumbnailUrl { get; }
		public string? Comment { get; }
		public string? FolderId { get; } = null!;
		public DriveFolder? Folder { get; }
		public string? UserId { get; }
		public User? User { get; }
	}
}
