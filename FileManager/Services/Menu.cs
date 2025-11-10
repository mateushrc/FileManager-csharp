using FileManager.Interfaces;
using System;

namespace FileManager.Services
{
    internal class Menu : IMenu
    {
        private readonly IFile _fileService;

        public Menu(IFile fileService)
        {
            _fileService = fileService;
        }

        public void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("File Manager");
                Console.WriteLine("------------\n");
                Console.WriteLine("1 - Create a file");
                Console.WriteLine("2 - Read a file");
                Console.WriteLine("3 - Update a file");
                Console.WriteLine("4 - Delete a file");
                Console.WriteLine("0 - Exit");
                Console.WriteLine("\n------------");

                Console.Write("Choice: ");
                var input = Console.ReadLine();

                if (!short.TryParse(input, out var choice))
                {
                    Console.WriteLine("Invalid Input, Try Again!");
                    continue;
                }

                switch (choice)
                {
                    case 1: _fileService.CreateFile(); break;
                    case 2: _fileService.ReadFile(); break;
                    case 3: _fileService.UpdateFile(); break;
                    case 4: _fileService.DeleteFile(); break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Input, Try Again!");
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
