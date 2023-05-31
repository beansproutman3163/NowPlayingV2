using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Page
	{
		[JsonProperty] string id = null!;
		public string Id => id;

		[JsonProperty] string createdAt = null!;
		public string CreatedAt => createdAt;       //TODO: DateTime

		[JsonProperty] string updatedAt = null!;
		public string UpdatedAt => updatedAt;

		[JsonProperty] string userId = null!;
		public string UserId => userId;

		[JsonProperty] User user = null!;
		public User User => user;

		[JsonProperty] Dictionary<string, string> content = null!;		// any?
		public Dictionary<string, string> Content => content;

		[JsonProperty] Dictionary<string, string> variables = null!;	// any?
		public Dictionary<string, string> Variables => variables;

		[JsonProperty] string title = null!;
		public string Title => title;

		[JsonProperty] string name = null!;
		public string Name => name;

		[JsonProperty] string? summary;
		public string? Summary => summary;

		[JsonProperty] bool hideTitleWhenPinned;
		public bool HideTitleWhenPinned => hideTitleWhenPinned;

		[JsonProperty] bool alignCenter;
		public bool AlignCenter => alignCenter;

		[JsonProperty] string font = null!;
		public string Font => font;

		[JsonProperty] string script = null!;
		public string Script => script;

		[JsonProperty] string? eyeCatchingImageId;
		public string? EyeCatchingImageId => eyeCatchingImageId;

		[JsonProperty] DriveFile? eyeCatchingImage;
		public DriveFile? EyeCatchingImage => eyeCatchingImage;

		[JsonProperty] List<DriveFile> attachedFiles = null!;
		public List<DriveFile> AttachedFiles => attachedFiles;

		[JsonProperty] int likedCount;
		public int LinkedCount => likedCount;

		[JsonProperty] bool isLinked;
		public bool IsLinked => isLinked;
		
	}
}
