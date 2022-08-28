using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P01_StudentSystem.Data.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [MaxLength(100)]
        [DataType("nvarchar")]
        [Required]
        public string Name{ get; set; }

        [StringLength(10)]
        [DataType("varchar")]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public DateTime? Birthday  { get; set; }

        public ICollection<Course> CourseEnrollments { get; set; }
        public ICollection<Homework> HomeworkSubmissions { get; set; }
    }
}
