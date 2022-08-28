using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }
        [MaxLength(50)]
        [Required]
        [DataType("nvarchar")]
        public string Name{ get; set; }
        [DataType("varchar")]
        [Required]
        public string Url { get; set; }
        [Required]
        public ResourceType ResourceType { get; set; }

        [ForeignKey(nameof(Course))]
        [Required]
        public int CourseId{ get; set; }
        public Course Course{ get; set; }
    }
}
