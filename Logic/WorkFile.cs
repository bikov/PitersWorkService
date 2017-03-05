using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PitersWorkService.DTO;
using PitersWorkService.Models;

namespace PitersWorkService.Logic
{
    class WorkFiles
    {
        private static readonly object LockObj = new object();
        private XmlSerializer _serializer;

        public WorkFiles()
        {
            _serializer = new XmlSerializer(typeof(WorkIndexes),new Type[] {typeof(WorkIndex)});
        }

        public string GetFilePathByRouteCard(string routeCard)
        {
            lock (LockObj)
            {
                using (FileStream fs = new FileStream(Config.WorksFileIndexesPath, FileMode.OpenOrCreate))
                {
                    if (fs.Length != 0)
                    {
                        WorkIndexes indexes = (WorkIndexes) _serializer.Deserialize(fs);
                    var firstOrDefault = indexes.WorkIndices.FirstOrDefault((index => index.RouteCard == routeCard));
                        if (firstOrDefault != null)
                        {
                            return (firstOrDefault.FileName);
                        }
                    }
                    return string.Empty;
                }
            }
        }

        public string GenerateFilePathAndSave(Work work)
        {
            lock (LockObj)
            {
                using (FileStream fs = new FileStream(Config.WorksFileIndexesPath, FileMode.OpenOrCreate))
                {
                    WorkIndexes indexes;
                    if (fs.Length != 0)
                    {
                        indexes = (WorkIndexes)_serializer.Deserialize(fs);
                    }
                    else
                    {
                        indexes = new WorkIndexes();
                    }
                    var filePath = Config.WorksFolderPath + $"//{work.RouteCard} - {work.DrawingNumber}.xml";
                    indexes.WorkIndices.Add(new WorkIndex(work.RouteCard,work.DrawingNumber,filePath));
                    _serializer.Serialize(fs, indexes);
                    return filePath;
                }
            }
        }
    }
}
