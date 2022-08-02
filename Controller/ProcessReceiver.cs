using System;
using System.Collections.Generic;
using System.IO;

namespace ZAW.MirrorCopy.Controller
{
    class ProcessReceiver
    {
        readonly string PathFolderReceiver; // приемник - куда
        readonly string PathJSONReceiver;

        public ProcessReceiver()
        {
            PathFolderReceiver = GlobalData.FullPathFolderCopy;
            PathJSONReceiver = PathFolderReceiver + "\\" + PathFolderReceiver.Substring(PathFolderReceiver.LastIndexOf("\\") + 1) + ".json";
        }

        /// <summary>Запускает работу с JSON-файлом</summary>
        public void Start(object dFiles)
        {
            var dictFilesReceiver = (Dictionary<string, DateTime>)dFiles;
            //DeserializeJSON();
            //SerializeJSON();
        }

        //private void SerializeJSON()
        //{
        //    throw new NotImplementedException();
        //}

        //private async void DeserializeJSON()
        //{
        //    throw new NotImplementedException();
        //    //var createStream = File.Create(PathJSONReceiver);
        //    //await JsonSerializer.SerializeAsync(createStream, weatherForecast);
        //    //await createStream.DisposeAsync();
        //}
    }
}
