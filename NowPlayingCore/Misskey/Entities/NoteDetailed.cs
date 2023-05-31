using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class NoteDetailed : Note
	{
		[JsonProperty] Note? reply;
		public Note? Reply => reply;

		[JsonProperty] NoteDetailed? renote;
		public NoteDetailed? Renote => renote;

		[JsonProperty] Poll? poll;
		public Poll? Poll => poll;

		[JsonProperty] string? myReaction;
		public string? MyReaction => myReaction;

	}
}
