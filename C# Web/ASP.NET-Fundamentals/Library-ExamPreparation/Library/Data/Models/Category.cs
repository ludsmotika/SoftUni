using System.ComponentModel.DataAnnotations;
using static Library.Common.EntityValidationsConstants.Category;

namespace Library.Data.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Book> Books { get; set; } = new HashSet<Book>();
    }
}
