using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Instance
	{
		public string? Name { get; }
		public string? SoftwareName { get; }
		public string? SoftwareVersion { get; }
		public string? IconUrl { get; }
		public string? FavIconUrl { get; }
		public string? ThemeColor { get; }
	}
}
