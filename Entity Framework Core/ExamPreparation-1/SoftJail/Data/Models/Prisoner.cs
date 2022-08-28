using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoftJail.Data.Models
{
    public class Prisoner
    {
        public Prisoner()
        {
            PrisonerOfficers = new HashSet<OfficerPrisoner>();
        }
        [Key]
        public int Id{ get; set; }

        [Required]
        [MaxLength(20)]
        public string FullName { get; set; }


        [Required]
        public string Nickname { get; set; }

        
        public int Age{ get; set; }

        [Required]
        public DateTime IncarcerationDate{ get; set; }


        public DateTime? ReleaseDate { get; set; }


        public decimal? Bail{ get; set; }

        [ForeignKey(nameof(Cell))]
        public int? CellId{ get; set; }
        public Cell? Cell{ get; set; }

        public ICollection<Mail> Mails{ get; set; }

        public ICollection<OfficerPrisoner> PrisonerOfficers { get; set; }
    }
}