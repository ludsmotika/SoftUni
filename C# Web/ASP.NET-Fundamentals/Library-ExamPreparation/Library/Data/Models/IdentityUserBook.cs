using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    public class IdentityUserBook
    {
        [Required]
        public string CollectorId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;
        
        [Required]
        public int BookId { get; set; }

        [Required]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
