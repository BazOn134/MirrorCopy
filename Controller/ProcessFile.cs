using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZAW.MirrorCopy.Controller
{
    class ProcessFile
    {
        readonly FileInfo File;

        public ProcessFile(FileInfo file)
        {
            File = file;
        }

        public void Start(Dictionary<string, DateTime> listFiles)
        {
            try
            {
                if (File.Name.ToString() != "Thumbs.db")
                {
                    listFiles.Add(File.FullName.ToString(), File.LastWriteTime);
                    Debug.WriteLine("Записан " + this.ToString());
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("--- WARN " + e.Message + ";  " + File.FullName.ToString());
                //throw;
            }
            Application.DoEvents();
        }

        public override string ToString()
        {
            return "Name: " + File.Name.ToString() + "; LastWriteTime: " + File.LastWriteTime.ToString();// base.ToString();
        }
    }
}
