using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PitersWorkService.Models
{

    [XmlRoot("WorkIndexs")]
    public class WorkIndexes
    {
        [XmlArray("WorkIndices")]
        [XmlArrayItem("WorkIndex")]
        public List<WorkIndex> WorkIndices { get; set; }

        public WorkIndexes()
        {
            WorkIndices = new List<WorkIndex>();
        }
    }

    [XmlType("WorkIndex")]
    public class WorkIndex
    {
        [XmlElement("RouteCard")]
        public string RouteCard { get; set; }

        [XmlElement("Drawing")]
        public string Drawing { get; set; }

        [XmlElement("FileName")]
        public string FileName { get; set; }

        public WorkIndex(string routeCard, string drawing, string fileName)
        {
            RouteCard = routeCard;
            Drawing = drawing;
            FileName = fileName;
        }

        public WorkIndex()
        {
            
        }

    }
}
