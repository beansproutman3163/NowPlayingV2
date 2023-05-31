using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class BadgeRole
	{
		[JsonProperty] string name = null!;
		public string Name => name;

		[JsonProperty] string? iconUrl;
		public string? IconUrl => iconUrl;

		[JsonProperty] int displayOrder;
		public int DisplayOrder => displayOrder;

	}
}
