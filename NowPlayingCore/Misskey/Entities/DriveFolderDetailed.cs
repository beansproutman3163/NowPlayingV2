using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class DriveFolderDetailed : DriveFolder
	{
		[JsonProperty] int foldersCount;
		public int FoldersCount => foldersCount;

		[JsonProperty] int filesCount;
		public int FilesCount => filesCount;

		[JsonProperty] DriveFolderDetailed? parent;
		public DriveFolderDetailed? Parent => parent;

	}
}
