using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Course
    {
        [Key]
        public int CourseId{ get; set; }

        [MaxLength(80)]
        [DataType("nvarchar")]
        [Required]
        public string Name { get; set; }
        [DataType("nvarchar")]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate{ get; set; }
        [Required]
        public DateTime EndDate{ get; set; }
        [Required]
        public decimal Price{ get; set; }

        public ICollection<Student> StudentsEnrolled { get; set; }
        public ICollection<Resource> Resources { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
