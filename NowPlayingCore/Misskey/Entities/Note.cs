using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Note
	{
		[JsonProperty] string id = null!;
		public string Id => id;

		[JsonProperty] string createdAt = null!;
		public string CreatedAt => createdAt;       //TODO: DateTime

		[JsonProperty] string userId = null!;
		public string UserId => userId;

		[JsonProperty] User? user;
		public User? User => user;

		[JsonProperty] string? text;
		public string? Text => text;

		[JsonProperty] string? cw;
		public string? Cw => cw;

		[JsonProperty] string visibility = null!;
		public string Visibility => visibility;

		[JsonProperty] bool localOnly;
		public bool LocalOnly => localOnly;

		[JsonProperty] string? reactionAcceptance;
		public string? ReactionAcceptance => reactionAcceptance;

		[JsonProperty] List<string>? visibleUserIds;
		public List<string>? VisibleUserIds => visibleUserIds;

		[JsonProperty] int renoteCount;
		public int RenoteCount => renoteCount;

		[JsonProperty] int repliesCount;
		public int RepliesCount => repliesCount;

		[JsonProperty] Dictionary<string, int> reactions = null!;
		public Dictionary<string, int> Reactions => reactions;

		[JsonProperty] Dictionary<string, string> reactionEmojis = null!;
		public Dictionary<string, string> ReactionEmojis => reactionEmojis;

		[JsonProperty] Dictionary<string, string>? emojis;
		public Dictionary<string, string>? Emojis => emojis;

		[JsonProperty] List<string>? tags;
		public List<string>? Tags => tags;

		[JsonProperty] List<string> fileIds = null!;
		public List<string> FileIds => fileIds;

		[JsonProperty] List<DriveFile> files = null!;
		public List<DriveFile> Files => files;

		[JsonProperty] string? replyId;
		public string? ReplyId => replyId;

		[JsonProperty] string? renoteId;
		public string? RenoteId => renoteId;

		[JsonProperty] string? channelId;
		public string? ChannelId => channelId;

		[JsonProperty] Channel? channel;
		public Channel? Channel => channel;

		[JsonProperty] List<string>? mentions;
		public List<string>? Mentions => mentions;

		[JsonProperty] string? url;
		public string? Url => url;

		[JsonProperty] string? uri;
		public string? Uri => uri;

	}
}
