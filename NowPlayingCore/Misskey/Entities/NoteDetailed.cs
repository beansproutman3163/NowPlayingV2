using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class NoteDetailed : Note
	{
		public Note? Reply { get; }
		public NoteDetailed? Renote { get; }
		public Poll? Poll { get; }
		public string? MyReaction { get; }
	}
}
