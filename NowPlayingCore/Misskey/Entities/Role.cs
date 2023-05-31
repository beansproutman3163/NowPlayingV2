using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Role
	{
		[JsonProperty] string id = null!;
		public string Id => id;

		[JsonProperty] string name = null!;
		public string Name => name;

		[JsonProperty] string? color;
		public string? Color => color;

		[JsonProperty] string? iconUrl;
		public string? IconUrl => iconUrl;

		[JsonProperty] string description = null!;
		public string Description => description;

		[JsonProperty] bool isModerator;
		public bool IsModerator => isModerator;

		[JsonProperty] bool isAdministrator;
		public bool IsAdministrator => isAdministrator;

		[JsonProperty] int displayOrder;
		public int DisplayOrder => displayOrder;

	}
}
