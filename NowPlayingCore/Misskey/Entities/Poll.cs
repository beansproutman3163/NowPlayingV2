using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Poll
	{
		[JsonProperty] bool multiple;
		public bool Multiple => multiple;

		[JsonProperty] string expiresAt = null!;	//TODO: DateTime
		public string ExpiresAt => expiresAt;

		[JsonProperty] List<PollChoice> choices = null!;
		public List<PollChoice> Choices => choices;

	}
}
