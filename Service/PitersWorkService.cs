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
        private XmlSerializer _staticDataSerializer;

        public PitersWorkService()
        {
            _staticDataSerializer = new XmlSerializer(typeof(StaticData), new Type[] { typeof(Material), typeof(Worker), typeof(Proiority) });
            _workSerializer = new XmlSerializer(typeof(Work),new Type[] {typeof(Material), typeof(Worker), typeof(StationWork), typeof(Proiority) });
            _workFiles = new WorkFiles();
        }


        public StaticData GetStaticData()
        {
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
                new Worker(1256320,45,"Piter","Udachin"),
                new Worker(123,45,"Bikov", "Vlad")
            };

            staticData.Stations = new List<Station>
            {
                new Station("Haas Vf3")
            };

            using (FileStream fs = new FileStream(Config.StaticDataFilePath, FileMode.Create))
            {
                _staticDataSerializer.Serialize(fs, staticData);
            }
            #endregion

            StaticData resulData;
            using (FileStream fs = new FileStream(Config.StaticDataFilePath, FileMode.Open))
            {
                resulData = (StaticData)_staticDataSerializer.Deserialize(fs);
            }

            return resulData;
        }

        public Worker GetWorker(int id)
        {
            using (FileStream fs = new FileStream(Config.StaticDataFilePath, FileMode.Open))
            {
                var staticData = (StaticData)_staticDataSerializer.Deserialize(fs);
                return staticData.Workers.SingleOrDefault(w => w.Workerid == id);
            }
        }

        public Work GetWork(string routeCard, string drawingNumber)
        {
            return GetWorkFromFile(routeCard, drawingNumber);
        }

        public void SaveWork(Work toSave)
        {
            var folderPath = $"{Config.WorksFolderPath}//{toSave.RouteCard}";
            using (FileStream fs = new FileStream($"{folderPath}//{toSave.DrawingNumber}.xml", FileMode.Create))
            {
                _workSerializer.Serialize(fs, toSave);
            }
        }

        private Work GetWorkFromFile(string routeCard, string drawingNumber)
        {
            Work retsultWork;
            var folderPath = $"{Config.WorksFolderPath}//{routeCard}";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream fs = new FileStream($"{folderPath}//{drawingNumber}.xml", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0)
                {
                    retsultWork = (Work) _workSerializer.Deserialize(fs);
                }
                else
                {
                    retsultWork = new Work();
                }
            }

            return retsultWork;
        }
    }
}
