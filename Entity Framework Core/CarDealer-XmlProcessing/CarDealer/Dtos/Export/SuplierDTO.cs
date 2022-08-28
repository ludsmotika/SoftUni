using CarDealer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("suplier")]
    public class SuplierDTO
    {
        [XmlAttribute("id")]
        public int Id{ get; set; }


        [XmlAttribute("name")]
        public string Name { get; set; }



        [XmlAttribute("parts-count")]
        public int partsCount { get; set; }

    }
}
