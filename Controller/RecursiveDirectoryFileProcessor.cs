using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ZAW.MirrorCopy;

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

        public void Start()
        {
            System.Windows.Forms.MessageBox.Show("Start");
            Thread.Sleep(3000);     // имитация продолжительной работы
        }
    }
}
