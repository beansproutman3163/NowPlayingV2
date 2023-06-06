using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace NowPlayingCore.Core
{
	public class MisskeyAccountInfo
	{
		/// <summary>
		/// API Token
		/// </summary>
		public string Token = default!;

		/// <summary>
		/// UserName without host name
		/// </summary>
		public string UserName = default!;

		/// <summary>
		/// Misskey server host name
		/// </summary>
		public string HostName = default!;

		/// <summary>
		/// User's display name
		/// </summary>
		public string DisplayName = default!;
	}

	public class MisskeyAccount : AccountContainer
	{
		public override string ID => $"@{info.UserName}@{info.HostName}";

		public override int MaxTweetLength => 3000;

		[JsonProperty]
		private MisskeyAccountInfo info;

#nullable disable
		// Will be called on Json.NET deserialization
		[JsonConstructor]
		private MisskeyAccount() { }
#nullable enable

		public MisskeyAccount(MisskeyAccountInfo info)
		{
			this.info = info;
			this.Name = info.DisplayName;
		}

		public override int CountText(string text) => CountTextStatic(text);

		static int CountTextStatic(string text)
		{
			//CRLF is counted as 2 chars(should be counted as 1 char)
			var repchar = text.Replace(Environment.NewLine, " ");
			var sinfo = new StringInfo(repchar);
			return sinfo.LengthInTextElements;
		}

		public override Task UpdateCache()
		{
			return Task.CompletedTask;
		}

		public override Task UpdateStatus(string UpdateText)
		{
			return Task.CompletedTask;
		}

		public override Task UpdateStatus(string UpdateText, string base64image)
		{
			return Task.CompletedTask;
		}
	}
}
