namespace PeTimeStampTool
{
	using PeTimeStampTool.Views;

	internal class Program
	{
		private static void Main(string[] args)
		{
			ConsoleView view = new ConsoleView(args);

			view.Show();
		}
	}
}