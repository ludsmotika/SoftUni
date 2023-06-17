using Homies.Models.Type;
using NuGet.Protocol.Core.Types;
using System.ComponentModel.DataAnnotations;
using static Homies.Common.EntityValidationsConstants.Event;

namespace Homies.Models.Event
{
    public class EventFormViewModel
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        public DateTime End { get; set; }


        [Range(1, int.MaxValue)]
        public int TypeId { get; set; }

        public IEnumerable<TypeViewModel> Types { get; set; } = new HashSet<TypeViewModel>();
    }
}
