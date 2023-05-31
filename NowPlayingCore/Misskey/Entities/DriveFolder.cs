using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class DriveFolder
	{
		[JsonProperty] string id => null!;
		public string Id => id!;

		[JsonProperty] string createdAt = null!;
		public string CreatedAt => createdAt;   //TODO: DateTime

		[JsonProperty] string name = null!;
		public string Name => name;

		[JsonProperty] string? parentId;
		public string? ParentId => parentId;

	}
}
