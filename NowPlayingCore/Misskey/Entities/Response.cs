using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Response
	{
		[JsonProperty] bool ok;
		public bool Ok => ok;
	}
}
