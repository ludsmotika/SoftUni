using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SoftJail.Data.Models
{
    public class Officer
    {
        public Officer()
        {
            OfficerPrisoners = new HashSet<OfficerPrisoner>();
        }
        [Key]
        public int Id{ get; set; }

        [Required]
        [MaxLength(30)]
        public string FullName{ get; set; }

        [Required]
        public decimal Salary{ get; set; }

        [Required]
        public Position Position  { get; set; }


        [Required]
        public Weapon Weapon  { get; set; }


        [ForeignKey(nameof(Department))]
        public int DepartmentId{ get; set; }
        public Department Department { get; set; }

        public ICollection<OfficerPrisoner> OfficerPrisoners  { get; set; }
    }
}
