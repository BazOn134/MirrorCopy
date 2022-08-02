using System.Collections.Generic;
using System.IO;
using System.Threading;
using static ZAW.MirrorCopy.MirrorCopyForm;

namespace ZAW.MirrorCopy.Controller
{
    class ProcessDirectory
    {
        readonly DirectoryInfo Dir;
        private FileInfo[] DictFiles;// = List<FileInfo>;
        private DirectoryInfo[] ListDirs;// = List<FileInfo>;

        public ProcessDirectory(DirectoryInfo directoryInfo)
        {
            Dir = directoryInfo;
        }

        public void Start(List<ProcessFile> listFiles)
        {
            if (!GlobalData.StageInProcess) return;
            //InsertStatusText("Обрабатывается папка " + Dir.Name); // изменяем элемент передав ему значение

            DictFiles = Dir.GetFiles();
            if (DictFiles.Length != 0)
            {
                foreach (var file in DictFiles)
                {
                    if (!GlobalData.StageInProcess) return;
                    listFiles.Add(new ProcessFile(file));
                }
            }
            
            ListDirs = Dir.GetDirectories();
            if (ListDirs.Length != 0)
            {
                foreach (var dir in ListDirs)
                {
                    new ProcessDirectory(dir).Start(listFiles);
                }
            }
        }
    }
}
