using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class DriveFileProperties
	{
		[JsonProperty] int width;
		public int Width => width;

		[JsonProperty] int height;
		public int Height => height;

		[JsonProperty] int orienration;
		public int Orientation => orienration;

		[JsonProperty] string? avgColor;
		public string? AvgColor => avgColor;
	}
}
