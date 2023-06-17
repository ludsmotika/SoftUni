using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Homies.Common.EntityValidationsConstants.Event;
namespace Homies.Data.Models
{
    public class Event
    {

        [Key]
        public int Id{ get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string OrganizerId { get; set; } = null!;

        //check if organizer need to have foreign key tag
        [Required]
        public IdentityUser Organizer { get; set; } = null!;


        //Add DateTime format on the 3 following props
        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        public DateTime Start { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "yyyy-MM-dd H:mm")]
        public DateTime End { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; } = null!;

        public IEnumerable<EventParticipant> EventsParticipants { get; set; } = new HashSet<EventParticipant>();

    }
}
