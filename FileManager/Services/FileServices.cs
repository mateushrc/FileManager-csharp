using FileManager.Interfaces;
using FileManager.Models;
using System.Text;

namespace FileManager.Services
{
    internal class FileServices : IFile
    {
        private readonly IFileRepository _repository;
        private readonly IErrorHandler _errorHandler;

        public FileServices(IFileRepository repository, IErrorHandler errorHandler)
        {
            _repository = repository;
            _errorHandler = errorHandler;
        }

        public FileModel? CreateFile()
        {
            try
            {
                Console.Clear();
                Console.Write("\nFile Name: ");
                var name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name)) return null;

                Console.Write("\nFile Extension (Default: .txt): ");
                var extension = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(extension)) extension = ".txt";

                Console.WriteLine("\nFile Content (type ':end' to finish): ");
                var content = new StringBuilder();
                string? line;
                while ((line = Console.ReadLine()) != ":end")
                    content.AppendLine(line);

                Console.Write("\nFile Path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(path)) return null;

                var file = new FileModel(name, extension, content.ToString(), path);
                _repository.Add(file);

                Console.WriteLine("\nArquivo criado com sucesso!");
                return file;
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex, "Erro ao criar arquivo");
                return null;
            }
        }

        public FileModel? ReadFile()
        {
            try
            {
                Console.Clear();
                Console.Write("\nFile Path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(path)) return null;

                var file = _repository.GetByPath(path);
                if (file == null)
                {
                    _errorHandler.Handle(new Exception("Arquivo não encontrado."), "ReadFile");
                    return null;
                }

                Console.WriteLine($"\nFile Name: {file.Name}{file.Extension}");
                Console.WriteLine($"\nFile Content:\n{file.Content}");
                Console.WriteLine("\nArquivo carregado com sucesso!");
                Console.ReadKey();
                return file;
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex, "Erro ao ler arquivo");
                return null;
            }
        }

        public bool UpdateFile()
        {
            try
            {
                Console.Clear();
                Console.Write("\nFile Path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(path)) return false;

                var existing = _repository.GetByPath(path);
                if (existing == null)
                {
                    _errorHandler.Handle(new Exception("Arquivo não encontrado."), "UpdateFile");
                    return false;
                }

                Console.WriteLine($"\nConteúdo atual:\n{existing.Content}");
                Console.WriteLine("\nNovo File Content (type ':end' to finish): ");

                var content = new StringBuilder();
                string? line;
                while ((line = Console.ReadLine()) != ":end")
                    content.AppendLine(line);

                var updated = new FileModel(existing.Name, existing.Extension, content.ToString(), existing.Path);
                var success = _repository.Update(updated);

                if (!success)
                {
                    _errorHandler.Handle(new Exception("Falha ao atualizar o arquivo."), "UpdateFile");
                    return false;
                }

                Console.WriteLine("\nArquivo atualizado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex, "Erro ao atualizar arquivo");
                return false;
            }
        }

        public bool DeleteFile()
        {
            try
            {
                Console.Clear();
                Console.Write("\nFile Path: ");
                var path = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(path)) return false;

                var existing = _repository.GetByPath(path);
                if (existing == null)
                {
                    _errorHandler.Handle(new Exception("Arquivo não encontrado."), "DeleteFile");
                    return false;
                }

                var success = _repository.Delete(path);
                if (!success)
                {
                    _errorHandler.Handle(new Exception("Falha ao deletar o arquivo."), "DeleteFile");
                    return false;
                }

                Console.WriteLine("\nArquivo deletado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                _errorHandler.Handle(ex, "Erro ao deletar arquivo");
                return false;
            }
        }
    }
}
