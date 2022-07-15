using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ZAW.MirrorCopy.Controller
{
    class ProcessDirectory
    {
        readonly DirectoryInfo Dir;
        private FileInfo[] ListFiles;// = List<FileInfo>;
        private DirectoryInfo[] ListDirs;// = List<FileInfo>;


        public ProcessDirectory(DirectoryInfo directoryInfo)
        {
            Dir = directoryInfo;
        }

        public void Start()
        {
            ListFiles = Dir.GetFiles();
            ListDirs = Dir.GetDirectories();
            if (ListFiles.Length != 0)
            {
                foreach (var file in ListFiles)
                {
                    new ProcessFile(file);
                }
            }
            if (ListDirs.Length != 0) 
            {
                foreach (var dir in ListDirs)
                {
                    new ProcessDirectory(dir);
                }
            }
        }
    }
}
