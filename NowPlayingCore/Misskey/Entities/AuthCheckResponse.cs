using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class AuthCheckResponse : Response
	{
		public string? Token { get; }
		public User? User { get; }
	}
}
