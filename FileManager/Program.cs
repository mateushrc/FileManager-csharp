using FileManager.Interfaces;
using FileManager.Repositorys;
using FileManager.Services;

namespace FileManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IFileRepository repository = new FileRepository();
            IErrorHandler errorHandler = new ErrorHandler();
            IFile fileService = new FileServices(repository, errorHandler);
            IMenu menu = new Menu(fileService);

            menu.Show();
        }
    }
}
