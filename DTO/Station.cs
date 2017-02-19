using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace PitersWorkService.DTO
{
    [DataContract]
    [XmlType("Station")]
    public class Station
    {
        [DataMember]
        [XmlElement("Name")]
        public string Name { get; set; }

        public Station()
        {
            
        }

        public Station(string stationName)
        {
            Name = stationName;
        }
    }
}
