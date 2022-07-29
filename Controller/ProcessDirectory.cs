using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Windows.Forms;

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

        public void Start(Dictionary<string, DateTime> listFiles)
        {
            //Thread.Sleep(3000); // имитация продолжительной работы
            if (!GlobalData.StageInProcess) return; 
            while (GlobalData.StageIsOnPause) 
            {
                System.Diagnostics.Debug.WriteLine("Процесс на паузе +++++++++++++++++++++");
                Thread.Sleep(1000); // пауза
            }
            ListFiles = Dir.GetFiles();
            ListDirs = Dir.GetDirectories();
            if (ListFiles.Length != 0)
            {
                foreach (var file in ListFiles)
                {
                    if (!GlobalData.StageInProcess) return;
                    new ProcessFile(file).Start(listFiles);
                }
            }
            if (ListDirs.Length != 0)
            {
                foreach (var dir in ListDirs)
                {
                    if (!GlobalData.StageInProcess) return;
                    new ProcessDirectory(dir).Start(listFiles);
                }
            }
        }
    }
}
