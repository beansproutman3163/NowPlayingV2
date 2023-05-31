using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Channel
	{
		[JsonProperty] string id = null!;
		public string Id => id;

		[JsonProperty] string name = null!;
		public string Name => name;

		[JsonProperty] string color = null!;
		public string Color => color;

	}
}
