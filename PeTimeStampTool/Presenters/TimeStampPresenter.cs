namespace PeTimeStampTool.Presenters
{
	using System;

	using PeTimeStampTool.Core;

	public class TimeStampPresenter
	{
		private static readonly FileHeaderReader _reader = new FileHeaderReader();

		private readonly string[] _args;

		public TimeStampPresenter(string[] args)
		{
			_args = args;
		}

		public string GetTimeStamp()
		{
			if (_args.Length == 0)
			{
				throw new InvalidOperationException("Please provide a path to the PE file.");
			}

			string path = _args[0];

			FileHeaderInfo info = _reader.GetFileHeader(path);

			return info.GetTimeStamp();
		}
	}
}