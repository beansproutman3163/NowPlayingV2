using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class Role
	{
		public string Id { get; } = null!;
		public string Name { get; } = null!;
		public string? Color { get; }
		public string? IconUrl { get; }
		public string Description { get; } = null!;
		public bool IsModerator { get; }
		public bool IsAdministrator { get; }
		public int DisplayOrder { get; }
	}
}
