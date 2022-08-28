using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Play")]
    public class PlayDTO
    {
        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Title{ get; set; }

        [Required]
        public string Duration{ get; set; }

        [Range(typeof(float),"0","10")]
        [Required]
        public float Rating{ get; set; }

        [Required]
        public string Genre { get; set; }
        [Required]
        [MaxLength(700)]
        public string Description { get; set; }
        [Required]
        [MinLength(4)]
        [MaxLength(30)]
        public string Screenwriter { get; set; }
    }
}
