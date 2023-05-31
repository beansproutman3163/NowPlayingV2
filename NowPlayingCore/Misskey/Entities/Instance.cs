using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Instance
	{
		[JsonProperty] string? name;
		public string? Name => name;

		[JsonProperty] string? softwareName;
		public string? SoftwareName => softwareName;

		[JsonProperty] string? softwareVersion;
		public string? SoftwareVersion => softwareVersion;

		[JsonProperty] string? iconUrl;
		public string? IconUrl => iconUrl;

		[JsonProperty] string? favIconUrl;
		public string? FavIconUrl => favIconUrl;

		[JsonProperty] string? themeColor;
		public string? ThemeColor => themeColor;

	}
}
