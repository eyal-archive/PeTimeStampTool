namespace PeTimeStampTool.Views
{
	using System;
	using System.IO;

	using PeTimeStampTool.Presenters;

	public class ConsoleView
	{
		private readonly TimeStampPresenter _presenter;

		public ConsoleView(string[] args)
		{
			_presenter = new TimeStampPresenter(args);
		}

		public void Show()
		{
			try
			{
				string timeStamp = _presenter.GetTimeStamp();

				Console.WriteLine(timeStamp);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine();
				Console.WriteLine(ex.Message);
			}
			catch (FileNotFoundException ex)
			{
				Console.WriteLine();
				Console.WriteLine(ex.Message);
			}
		}
	}
}