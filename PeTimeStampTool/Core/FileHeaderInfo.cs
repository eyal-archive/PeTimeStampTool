namespace PeTimeStampTool.Core
{
	using System;

	using PeTimeStampTool.Core.Native;

	public class FileHeaderInfo
	{
		private readonly IMAGE_FILE_HEADER _header;

		internal FileHeaderInfo(IMAGE_FILE_HEADER header)
		{
			_header = header;
		}

		public string GetTimeStamp(string format = "X")
		{
			try
			{
				return _header.TimeDateStamp.ToString(format);
			}
			catch (FormatException)
			{
				return _header.TimeDateStamp.ToString("X");
			}
		}
	}
}