using System;
using System.Collections.Generic;
using System.Text;

namespace NowPlayingCore.Misskey.Entities
{
	public class DriveFolderDetailed : DriveFolder
	{
		public int FoldersCout { get; }
		public int FilesCount { get; }
		public DriveFolderDetailed? Parent { get; }
	}
}
