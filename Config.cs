using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PitersWorkService
{
    internal static class Config
    {
        public static string DataFolderPath = ConfigurationManager.AppSettings["DataFolderPath"];//"C:\\Temp\\PitersWorkData";

        public static string StaticDataFilePath = $"{DataFolderPath}\\{ConfigurationManager.AppSettings["StaticDataFile"]}";

        public static string WorksFileIndexesPath = $"{DataFolderPath}\\{ConfigurationManager.AppSettings["WorksFileIndexes"]}";

        public static string WorksFolderPath = $"{DataFolderPath}\\{ConfigurationManager.AppSettings["WorksFolder"]}";
    }
}
