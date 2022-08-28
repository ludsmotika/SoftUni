using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("car")]
    public class CarDTOExport
    {
        [XmlElement("make")]
        public string Make { get; set; }


        [XmlElement("model")]
        public string Model { get; set; }


        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }

    }
}