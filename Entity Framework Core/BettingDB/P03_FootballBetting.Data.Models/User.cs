using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace P03_FootballBetting.Data.Models
{
    public class User
    {
        public User()
        {
            Bets= new HashSet<Bet>();
        }
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }


        [Required]
        [MaxLength(50)]
        public string Email { get; set; }


        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        public decimal Balance{ get; set; }

        public ICollection<Bet> Bets{ get; set; }
    }
}
