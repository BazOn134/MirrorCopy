using System.Collections.Generic;
using System.IO;

namespace ZAW.MirrorCopy.Controller
{
    class RecursiveDirectoryFileProcessor
    {
        readonly string PathFolderSender;

        public RecursiveDirectoryFileProcessor()
        {
            PathFolderSender = GlobalData.FullPathFolderOrig;
        }

        public void Start(object lFiles)
        {
            var listFiles = (List<ProcessFile>)lFiles;
            if (Directory.Exists(PathFolderSender))
            {
                var processDirectory = new ProcessDirectory(new DirectoryInfo(PathFolderSender));
                processDirectory.Start(listFiles);
            }
            GlobalData.StageInProcess = false;
        }

    }
}
