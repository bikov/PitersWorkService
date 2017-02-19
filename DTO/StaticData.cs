using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PitersWorkService.DTO
{
    [XmlRoot("StaticData")]
    [XmlInclude(typeof(Material))]
    [XmlInclude(typeof(Worker))]
    [XmlInclude(typeof(Proiority))]
    [DataContract]
    public class StaticData
    {
        [XmlArray("Materials")]
        [XmlArrayItem("Material")]
        [DataMember]
        public List<Material> Materials { get; set; }

        [XmlArray("WorkerSalaries")]
        [XmlArrayItem("WorkerSalary")]
        [DataMember]
        public List<Worker> Workers { get; set; }

        [XmlArray("Proiorities")]
        [XmlArrayItem("Proiority")]
        [DataMember]
        public List<Proiority> Proiorities { get; set; }
    }
}
