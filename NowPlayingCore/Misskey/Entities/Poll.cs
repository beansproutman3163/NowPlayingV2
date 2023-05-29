using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Poll
	{
		public bool Multiple { get; }
		public string ExpiresAt { get; } = null!; // DateTime
		public class Choice
		{
			public string Text { get; } = null!;
			public int Votes { get; }
			public bool IsVoted { get; }
		}
		public Choice[] Choices { get; } = null!;
	}
}
