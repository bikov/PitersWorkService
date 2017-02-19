using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using PitersWorkService.Contracts;
using PitersWorkService.DTO;
using PitersWorkService.Logic;
using PitersWorkService.Models;

namespace PitersWorkService.Service
{
    class PitersWorkService : IPitersWorkConteract
    {
        private WorkFiles _workFiles;
        private XmlSerializer _workSerializer;

        public PitersWorkService()
        {
            _workSerializer = new XmlSerializer(typeof(Work),new Type[] {typeof(Material), typeof(Worker), typeof(StationWork), typeof(Proiority) });
            _workFiles = new WorkFiles();
        }


        public StaticData GetStaticData()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(StaticData), new Type[] { typeof(Material), typeof(Worker), typeof(Proiority) });

            #region ToDeletelatter

            var staticData = new StaticData();
            staticData.Materials = new List<Material>{
                new Material("Aluminium",3.7,21,24),
                new Material("Brass", 8.5, 40, 40),
                new Material("Toolsteel", 7.8, 17, 19)
            };

            staticData.Proiorities = new List<Proiority>
            {
                new Proiority(1,2),
                new Proiority(2,1.6),
                new Proiority(3,1)
            };

            staticData.Workers= new List<Worker>
            {
                new Worker(1256320,45)
            };

            using (FileStream fs = new FileStream(Config.StaticDataFilePath, FileMode.Create))
            {
                serializer.Serialize(fs, staticData);
            }
            #endregion

            StaticData resulData;
            using (FileStream fs = new FileStream(Config.StaticDataFilePath, FileMode.Open))
            {
                resulData = (StaticData)serializer.Deserialize(fs);
            }

            return resulData;
        }

        public Work GetWorkByDrawingNumber(string drawingNumber)
        {
            var filePath = _workFiles.GetFilePathByDrawingNumber(drawingNumber);
            return GetWorkFromFile(filePath);
        }

        public Work GetWorkByRouteCard(string routeCard)
        {
            var filePath = _workFiles.GetFilePathByRouteCard(routeCard);
            return GetWorkFromFile(filePath);
        }

        public void SaveWork(Work toSave)
        {
            var filePath = _workFiles.GetFilePathByDrawingNumber(toSave.DrawingNumber);
            if (filePath.Equals(string.Empty))
            {
                filePath= _workFiles.GenerateFilePathAndSave(toSave);
            }
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                _workSerializer.Serialize(fs, toSave);
            }
        }

        private Work GetWorkFromFile(string filePath)
        {
            Work retsultWork;
            if (filePath.Equals(string.Empty))
            {
                retsultWork = new Work();
            }
            else
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open))
                {
                    retsultWork = (Work)_workSerializer.Deserialize(fs);
                }
            }

            return retsultWork;
        }
    }
}
