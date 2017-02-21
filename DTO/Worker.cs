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

        [DataMember]
        [XmlElement("FirstName")]
        public string FirstName{ get; set; }

        [DataMember]
        [XmlElement("Lastname")]
        public string Lastname { get; set; }

        public Worker(int workerid, int hourlyRate, string firstName, string lastname)
        {
            Workerid = workerid;
            HourlyRate = hourlyRate;
            FirstName = firstName;
            Lastname = lastname;
        }

        public Worker()
        {   
        }
    }
}
