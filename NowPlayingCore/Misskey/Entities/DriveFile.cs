using CoreTweet;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class DriveFile
	{
		[JsonProperty] string id = null!;
		public string Id => id;

		[JsonProperty] string createdAt = null!;
		public string CreatedAt => createdAt;		//TODO: DateTime

		[JsonProperty] string name = null!;
		public string Name => name;

		[JsonProperty] string type = null!;
		public string Type => type;

		[JsonProperty] string md5 = null!;
		public string MD5 => md5;

		[JsonProperty] int size;
		public int Size => size;

		[JsonProperty] bool isSensitive;
		public bool IsSensitive => isSensitive;

		[JsonProperty] string blurhash = null!;
		public string BlurHash => blurhash;

		[JsonProperty] DriveFileProperties properties = null!;
		public DriveFileProperties Properties => properties;

		[JsonProperty] string url = null!;
		public string Url => url;

		[JsonProperty] string? thumbnailUrl;
		public string? ThumbnailUrl => thumbnailUrl;

		[JsonProperty] string? comment;
		public string? Comment => comment;

		[JsonProperty] string? folderId = null!;
		public string? FolderId => folderId;

		[JsonProperty] DriveFolder? folder;
		public DriveFolder? Folder => folder;

		[JsonProperty] string? userId;
		public string? UserId => userId;

		[JsonProperty] User? user;
		public User? User => user;

	}
}
