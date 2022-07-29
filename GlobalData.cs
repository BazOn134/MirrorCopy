using System;
using System.Collections.Generic;

namespace ZAW.MirrorCopy
{
    public static class GlobalData
    {
        public static string FullPathFolderOrig { get; set; }
        public static string FullPathFolderCopy { get; set; }
        public static string FullPathFolderArch { get; set; }
        public static bool FullPathLogSaveToFile { get; set; }
        public static bool StageInProcess = false;
        public static bool StageIsOnPause = false;
    }

}
