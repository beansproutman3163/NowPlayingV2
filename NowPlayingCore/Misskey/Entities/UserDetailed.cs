using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class UserDetailed : User
	{
		[JsonProperty] string? url;
		public string? Url => url;

		[JsonProperty] string? uri;
		public string? Uri => uri;

		[JsonProperty] string? moveTo;
		public string? MoveTo => moveTo;

		[JsonProperty] List<string>? alsoKnownAs;
		public List<string>? AlsoKnownAs => alsoKnownAs;

		[JsonProperty] string createdAt = null!;
		public string CreatedAt => createdAt;			//TODO: DateTime

		[JsonProperty] string? updatedAt;
		public string? UpdatedAt => updatedAt;			//TODO: DateTime

		[JsonProperty] string? lastFetchedAt;
		public string? LastFetchedAt => lastFetchedAt;  //TODO: DateTime

		[JsonProperty] string? bannerUrl;
		public string? BannerUrl => bannerUrl;

		[JsonProperty] string? bannarBlurhash;
		public string? BannerBlurhash => bannarBlurhash;

		[JsonProperty] bool isLocked;
		public bool IsLocked => isLocked;

		[JsonProperty] bool isSilenced;
		public bool IsSilenced => isSilenced;

		[JsonProperty] bool isSuspended;
		public bool IsSuspended => isSuspended;

		[JsonProperty] string? description;
		public string? Description => description;

		[JsonProperty] string? location;
		public string? Location => location;

		[JsonProperty] string? birthday;
		public string? Birthday => birthday;

		[JsonProperty] string? lang;
		public string? Lang => lang;

		[JsonProperty] List<Field> fields = null!;
		public List<Field> Fields => fields;

		[JsonProperty] int followersCount;
		public int FollowersCount => followersCount;

		[JsonProperty] int followingCount;
		public int FollowingCount => followingCount;

		[JsonProperty] int notesCount;
		public int NotesCount => notesCount;

		[JsonProperty] List<string> pinnedNoteIds = null!;
		public List<string> PinnedNoteIds => pinnedNoteIds;

		[JsonProperty] List<Note> pinnedNotes = null!;
		public List<Note> PinnedNotes => pinnedNotes;

		[JsonProperty] string? pinnedPageId;
		public string? PinnedPageId => pinnedPageId;

		[JsonProperty] Page? pinnedPage;
		public Page? PinnedPage => pinnedPage;

		[JsonProperty] bool publicReactions;
		public bool PublicReactions => publicReactions;

		[JsonProperty] string ffVisibility = null!;
		public string FFVisibility => ffVisibility;

		[JsonProperty] bool twoFactorEnabled;
		public bool TwoFactorEnabled => twoFactorEnabled;

		[JsonProperty] bool usePasswordLessLogin;
		public bool UsePasswordLessLogin => usePasswordLessLogin;

		[JsonProperty] bool securityKeys;
		public bool SecurityKeys => securityKeys;

		[JsonProperty] List<Role> roles = null!;
		public List<Role> Roles => roles;

		[JsonProperty] string? memo;
		public string? Memo => memo;

	}
}
