using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Note
	{
		public string Id { get; } = null!;
		public string CreatedAt { get; } = null!; // DateTime
		public string UserId {  get; } = null!;
		public User? User { get; }
		public string? Text { get; }
		public string? Cw { get; }
		public string Visibility { get; } = null!;
		public bool LocalOnly;
		public string? ReactionAcceptance { get; }
		public string[]? VisibleUserIds { get; }
		public int ReNoteCount;
		public int RepliesCount;
		public Dictionary<string, int> Reactions { get; } = null!;
		public Dictionary<string, string> ReactionEmojis { get; } = null!;
		public Dictionary<string, string>? Emojis { get; }
		public string[]? Tags { get; }
		public string[] FileIds { get; } = null!;
		public DriveFile[] Files { get; } = null!;
		public string? ReplyId { get; }
		public string? RenoteId { get; }
		public string? ChannelId { get; }
		public Channel? Channel { get; }
		public string[]? Mentions { get; }

		/// https://github.com/misskey-dev/misskey/blob/develop/packages/backend/src/core/entities/NoteEntityService.ts#L53
	}
}
