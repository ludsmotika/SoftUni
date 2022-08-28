using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Theatre.Data.Models.Enums;

namespace Theatre.DataProcessor.ExportDto
{
    [XmlType("Play")]
    public class PlayExportDTO
    {
        [XmlAttribute("Title")]
        public string Title { get; set; }


        [XmlAttribute("Duration")]
        public string Duration { get; set; }



        [XmlAttribute("Rating")]
        public string Rating { get; set; }


        [XmlAttribute("Genre")]
        public Genre Genre { get; set; }

        [XmlArray("Actors")]
        public List<CastExportDTO> Actors { get; set; }
    }
}
