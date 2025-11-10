namespace FileManager.Models
{
    internal class FileModel
    {
        public string Name { get; }
        public string Extension { get; }
        public string Content { get; }
        public string Path { get; }

        public FileModel(string name, string? extension, string? content, string path)
        {
            Name = name;
            Extension = string.IsNullOrWhiteSpace(extension) ? ".txt" : extension;
            Content = content ?? string.Empty;
            Path = path.EndsWith('/') || path.EndsWith('\\') ? path : path + '/';

            var fullPath = System.IO.Path.Combine(Path, Name + Extension);
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fullPath)!);
        }
    }
}
