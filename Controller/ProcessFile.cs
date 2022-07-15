using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAW.MirrorCopy.Controller
{
    class ProcessFile
    {
        readonly FileInfo File;

        public ProcessFile(FileInfo file)
        {
            File = file;
        }

        public void Start()
        {
            System.Windows.Forms.MessageBox.Show("ProcessFile =" + File.Name);
        }

    }
}
