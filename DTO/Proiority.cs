using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace PitersWorkService.DTO
{
    [DataContract]
    [XmlType("Proiority")]
    public class Proiority
    {
        [DataMember]
        [XmlElement("ProiorityNumber")]
        public int ProiorityNumber { get; set; }

        [DataMember]
        [XmlElement("PriorityRate")]
        public double PriorityRate { get; set; }

        public Proiority(int proiorityNumber, double priorityRate)
        {
            ProiorityNumber = proiorityNumber;
            PriorityRate = priorityRate;
        }

        public Proiority()
        {
            
        }
    }
}
