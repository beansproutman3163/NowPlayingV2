using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class BadgeRole
	{
		public string Name { get; } = null!;
		public string? IconUrl { get; }
		public int DisplayOrder { get; }
	}
}
