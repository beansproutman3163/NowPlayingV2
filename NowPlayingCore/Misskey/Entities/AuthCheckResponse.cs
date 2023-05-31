using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class AuthCheckResponse : Response
	{
		[JsonProperty] string? token;
		public string? Token => token;

		[JsonProperty] UserDetailed? user;
		public UserDetailed? User => user;

	}
}
