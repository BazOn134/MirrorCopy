using System;
using System.IO;

namespace ZAW.MirrorCopy.Controller
{
    public class ProcessFile
    {
        public string Name { get; private set; }
        public string FullName { get; private set; }
        public DateTime ModifiedDate { get; private set; }

        public ProcessFile(FileInfo file)
        {
            Name = file.Name;
            FullName = file.FullName;
            ModifiedDate = file.LastWriteTime;
        }

        public override string ToString()
        {
            return $"Name: {Name};\t ModifiedDate: {ModifiedDate}";
        }
    }
}
