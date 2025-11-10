using FileManager.Interfaces;
using FileManager.Models;

namespace FileManager.Repositorys
{
    internal class FileRepository : IFileRepository
    {
        private readonly List<FileModel> _files = new();

        public FileModel? GetByPath(string path)
            => _files.Find(f => f.Path == path);

        public void Add(FileModel file)
            => _files.Add(file);

        public bool Update(FileModel file)
        {
            var existing = GetByPath(file.Path);
            if (existing == null) return false;
            _files.Remove(existing);
            _files.Add(file);
            return true;
        }

        public bool Delete(string path)
        {
            var file = GetByPath(path);
            if (file == null) return false;
            _files.Remove(file);
            return true;
        }
    }
}
