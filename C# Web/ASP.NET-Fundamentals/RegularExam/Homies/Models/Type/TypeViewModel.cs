using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidationsConstants.Type;

namespace Homies.Models.Type
{
    public class TypeViewModel
    {

        public int Id { get; set; }

        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;
    }
}
