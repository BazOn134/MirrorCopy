using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZAW.MirrorCopy;
using System.Windows.Forms;

namespace ZAW.MirrorCopy.Controller
{
    class RecursiveDirectoryFileProcessor
    {
        readonly string PathFolderSender; // передатчик - откуда
        readonly string PathFolderReceiver; // приемник - куда

        public RecursiveDirectoryFileProcessor()
        {
            PathFolderSender = GlobalData.FullPathFolderOrig;
            PathFolderReceiver = GlobalData.FullPathFolderCopy;
        }

        public void Start(object lFiles)
        {
            //ТОДО разработать логику обработки дерева файлов
            var listFiles = (Dictionary<string, DateTime>)lFiles;
            System.Diagnostics.Debug.WriteLine("Start RecursiveDirectoryFileProcessor ======================================================");
            if (Directory.Exists(PathFolderSender))
            {
                var processDirectory = new ProcessDirectory(new DirectoryInfo(PathFolderSender));
                processDirectory.Start(listFiles);
            }
            GlobalData.StageInProcess = false;
            GlobalData.StageIsOnPause = false;
        }

    }
}
