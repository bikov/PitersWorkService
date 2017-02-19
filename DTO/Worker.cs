using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PitersWorkService.DTO
{
    [DataContract]
    [XmlType("Worker")]
    public class Worker
    {
        [DataMember]
        [XmlElement("Workerid")]
        public int Workerid { get; set; }

        [DataMember]
        [XmlElement("HourlyRate")]
        public int HourlyRate { get; set; }

        public Worker(int workerid, int hourlyRate)
        {
            Workerid = workerid;
            HourlyRate = hourlyRate;
        }

        public Worker()
        {   
        }
    }
}
