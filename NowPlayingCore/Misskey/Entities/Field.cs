using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Field
	{
		[JsonProperty] string name = null!;
		public string Name => name;

		[JsonProperty] string value = null!;
		public string Value => value;

	}
}
