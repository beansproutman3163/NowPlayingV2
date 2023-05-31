using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class PollChoice
	{
		[JsonProperty] string text = null!;
		public string Text => text;

		[JsonProperty] int votes;
		public int Votes => votes;

		[JsonProperty] bool isVoted;
		public bool IsVoted => isVoted;

	}
}
