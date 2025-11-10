using FileManager.Models;

namespace FileManager.Interfaces
{
    internal interface IFileRepository
    {
        FileModel? GetByPath(string path);
        void Add(FileModel file);
        bool Update(FileModel file);
        bool Delete(string path);
    }
}
