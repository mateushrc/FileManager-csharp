using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using FileManager.Models;

namespace FileManager.Interfaces
{
    internal interface IFile
    {
        public FileModel? CreateFile();
        public FileModel? ReadFile();
        public bool UpdateFile();
        public bool DeleteFile();
    }
}
