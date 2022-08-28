using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MusicHub.Data.Models
{
    public class Album
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Name { get; set; }


        [Required]
        public DateTime ReleaseDate { get; set; }

        public decimal Price  { get { return Songs.Select(x => x.Price).Sum(); } }


        [ForeignKey(nameof(Producer))]
        public int? ProducerId { get; set; }
        public Producer Producer{ get; set; }

        public List<Song> Songs { get; set; }
    }
}
