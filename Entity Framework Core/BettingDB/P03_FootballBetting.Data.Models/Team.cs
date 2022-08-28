using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class Team
    {

        public Team()
        {
            HomeGames = new HashSet<Game>();
            AwayGames = new HashSet<Game>();
            Players = new HashSet<Player>();
        }


        [Key]
        public int TeamId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string LogoUrl { get; set; }

        [Required]
        [MaxLength(5)]
        public string Initials { get; set; }

        [Required]
        public decimal Budget { get; set; }



        [ForeignKey(nameof(PrimaryKitColor))]
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor{ get; set; }


        [ForeignKey(nameof(SecondaryKitColor))]
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }



        [ForeignKey(nameof(Town))]
        public int TownId { get; set; }
        public Town Town{ get; set; }

        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames{ get; set; }

        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames { get; set; }


        public ICollection<Player> Players{ get; set; }
    }
}
