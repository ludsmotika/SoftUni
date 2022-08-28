using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace Theatre.DataProcessor.ImportDto
{
    [XmlType("Cast")]
    public class CastDTO
    {
        [Required]
        [MaxLength(30)]
        [MinLength(4)]
        public string FullName{ get; set; }
        [Required]
        public bool IsMainCharacter { get; set; }
        [RegularExpression(@"^\+44-[0-9][0-9]-[0-9][0-9][0-9]-[0-9][0-9][0-9][0-9]$")]
        public string PhoneNumber { get; set; }
        [Required]
        public int PlayId{ get; set; }
    }
}
