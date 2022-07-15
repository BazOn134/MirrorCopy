using System;
using System.Collections.Generic;
using System.IO;
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
            //ТОДО разработать логику обработки дерева файлов
            System.Windows.Forms.MessageBox.Show("Start");
            if (Directory.Exists(PathFolderSender))
            {
                var Process = new ProcessDirectory(new DirectoryInfo(PathFolderSender));
                Process.Start();
            }

            Thread.Sleep(3000); // имитация продолжительной работы
        }
        
        
        
        
        public void ProcessDirectory1(string targetDirectory) // Обработайте все файлы в переданном каталоге, выполните повторный поиск по любым найденным каталогам и обработайте содержащиеся в них файлы.
        {
            //string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory); // Выполните рекурсию в подкаталоги этого каталога.
            //foreach (string subdirectory in subdirectoryEntries)
            //{
            //    var newDirectory = subdirectory.Replace(PathFolderSender, PathFolderReceiver);
            //    if (!Directory.Exists(newDirectory))
            //    {
            //        Directory.CreateDirectory(newDirectory);
            //        if (Data.FullPathLogSaveToFile) Logger.Info("Создана папка      '" + newDirectory);
            //    }
            //    ProcessDirectory(subdirectory);
            //}

            //string[] fileEntries = Directory.GetFiles(targetDirectory); // Обработайте список файлов, найденных в каталоге.
            //foreach (string fileName in fileEntries)
            //{
            //    var newFile = fileName.Replace(PathFolderSender, PathFolderReceiver);
            //    if (File.Exists(newFile))
            //    {
            //        if (Data.FullPathLogSaveToFile) Logger.Info("Файл существует '" + newFile);
            //    }
            //    else
            //    {
            //        try
            //        {
            //            File.Copy(fileName, newFile, true);
            //            if (Data.FullPathLogSaveToFile) Logger.Info("Файл скопирован в '" + newFile);
            //        }
            //        catch (Exception)
            //        {
            //            if (Data.FullPathLogSaveToFile) Logger.Info("Ошибка при копировании файла '" + newFile);
            //        }
            //    }
            //}
        }

    }
}
