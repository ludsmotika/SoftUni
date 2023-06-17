using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidationsConstants.Type;

namespace Homies.Data.Models
{
    public class Type
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Event> Events { get; set; } = new HashSet<Event>();
    }
}
