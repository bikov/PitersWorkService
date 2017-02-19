using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PitersWorkService.DTO
{
    [DataContract]
    [XmlRoot("Work")]
    [XmlInclude(typeof(Material))]
    [XmlInclude(typeof(Worker))]
    [XmlInclude(typeof(StationWork))]
    [XmlInclude(typeof(Proiority))]
    public class Work
    {
        [DataMember]
        [XmlElement("RouteCard")]
        public string RouteCard { get; set; }

        [DataMember]
        [XmlElement("DrawingNumber")]
        public string DrawingNumber { get; set; }

        [DataMember]
        [XmlElement("Material")]
        public Material Material { get; set; }

        [DataMember]
        [XmlElement("Quantity")]
        public int Quantity { get; set; }

        [DataMember]
        [XmlElement("Worker")]
        public Worker Worker { get; set; }

        [XmlArray("StationWorks")]
        [XmlArrayItem("StationWork")]
        [DataMember]
        public List<StationWork> StationWorks { get; set; }

        [DataMember]
        [XmlElement("Proiority")]
        public Proiority Proiority { get; set; }

        public Work(string routeCard, string drawingNumber, Material material, int quantity, Worker worker, List<StationWork> stationWorks, Proiority proiority)
        {
            RouteCard = routeCard;
            DrawingNumber = drawingNumber;
            Material = material;
            Quantity = quantity;
            Worker = worker;
            StationWorks = stationWorks;
            Proiority = proiority;
        }

        public Work()
        {
        }
    }
}
