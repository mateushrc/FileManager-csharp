using FileManager.Interfaces;

namespace FileManager.Services
{
	internal class ErrorHandler : IErrorHandler
	{
		public void Handle(Exception ex, string context = "")
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine($"\n[ERROR] {context}: {ex.Message}");
			Console.ResetColor();
			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
	}
}
