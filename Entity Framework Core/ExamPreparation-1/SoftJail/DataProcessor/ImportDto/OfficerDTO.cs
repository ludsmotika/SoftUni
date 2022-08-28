using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerDTO
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(3)]
        [MaxLength(30)]
        public string FullName{ get; set; }

        [XmlElement("Money")]
        [Range(typeof(decimal),"0", "79228162514264337593543950335")]
        public decimal Salary { get; set; }
        [Required]
        public string Position{ get; set; }


        [Required]
        public string Weapon{ get; set; }

        public int DepartmentId { get; set; }

        public List<PrisonerIdDTO> Prisoners { get; set; }
    }
}
