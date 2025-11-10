namespace FileManager.Interfaces
{
	internal interface IErrorHandler
	{
		void Handle(Exception ex, string context = "");
	}
}
