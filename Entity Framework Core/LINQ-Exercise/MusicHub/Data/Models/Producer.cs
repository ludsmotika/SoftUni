using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Producer
    {
        [Key]
        public int Id{ get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        public string Pseudonym{ get; set; }
        public string PhoneNumber{ get; set; }

        public List<Album> Albums { get; set; }
    }
}
