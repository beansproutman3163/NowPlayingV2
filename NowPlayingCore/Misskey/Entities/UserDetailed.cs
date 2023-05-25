using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class UserDetailed : User
	{
		public string? Url { get; }
		public string? Uri { get; }
		public string? MoveTo { get; }
		public string[]? AlsoKnownAs { get; }
		public string CreatedAt = null!;	// DateTime
		public string? UpdatedAt;			// DateTime
		public string? LastFetchedAt;		// DateTime
		public string? BannerUrl;
		public string? BannerBlurhash;
		public bool IsLocked { get; }
		public bool IsSilenced { get; }
		public bool IsSuspended { get; }
		public string? Description { get; }
		public string? Location { get; }
		public string? Birthday { get; }
		public string? Lang { get; }
		public Field[] Fields { get; } = null!;
		public int FollowersCount;
		public int FollowingCount;
		public int NotesCount;
		public string[] PinnedNotesIds { get; } = null!;
		public Note[] PinnedNotes { get; } = null!;
		public string? PinnedPageId { get; }
		public Page? PinnedPage { get; }
		public bool PublicReactions { get; }
		public string FFVisibility { get; } = null!;
		public bool TwoFactorEnabled { get; }
		public bool UsePasswordLessLogin { get; }
		public bool SecurityKeys { get; }
		public Role[] Roles { get; } = null!;
		public string? Memo { get; }
	}
}
