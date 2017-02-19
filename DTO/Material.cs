using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PitersWorkService.DTO
{
    [DataContract]
    [XmlType("Material")]
    public class Material
    {
        [DataMember]
        [XmlElement("Name")]
        public string Name { get; set; }

        [DataMember]
        [XmlElement("Density")]
        public double Density { get; set; }

        [DataMember]
        [XmlElement("RoundBar")]
        public double RoundBar { get; set; }

        [DataMember]
        [XmlElement("Profile")]
        public double Profile { get; set; }

        public Material(string name, double density, double roundBar, double profile)
        {
            this.Name = name;
            this.Density = density;
            this.RoundBar = roundBar;
            this.Profile = profile;
        }

        public Material()
        {
            
        }
    }
}
