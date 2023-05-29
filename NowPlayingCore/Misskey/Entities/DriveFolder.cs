using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class DriveFolder
	{
		public string Id { get; } = null!;
		public string CreatedAt { get; } = null!; // DateTime
		public string Name { get; } = null!;
		public string? ParentId { get; }
	}
}
