using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PitersWorkService.DTO
{
    [DataContract]
    [XmlType("StationWork")]
    public class StationWork
    {
        [DataMember]
        [XmlElement("Station")]
        public Station Station { get; set; }

        [DataMember]
        [XmlElement("SetupTime")]
        public double SetupTime { get; set; }

        [DataMember]
        [XmlElement("ProductionType")]
        public double ProductionTime { get; set; }

        public StationWork()
        {
            
        }

        public StationWork(Station station, double setupTime, double productionTime)
        {
            Station = station;
            SetupTime = setupTime;
            ProductionTime = productionTime;
        }
    }
}
