using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EMSWebApp.Models.ModelEnums;

namespace EMSWebApp.Models
{
    public class UserEvent
    {
        [Key]
        public Guid Id { get; set; }

        public int AppUserId { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public AppUser ? AppUser { get; set; }

        [Required(ErrorMessage = "Event title is required."), MaxLength(150)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(1000)]
        public string Description { get; set; } = string.Empty;

        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;

        [MaxLength(2048)]
        public string StorageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; } = string.Empty;

        public int? Capacity { get; set; }

        [Required(ErrorMessage = "Event type is required.")]
        public EventTypeEnum EventType { get; set; }

        [Required(ErrorMessage = "Venue is required.")]
        public Guid? VenueId { get; set; }

        [ForeignKey(nameof(VenueId))]
        public Venue? Venue { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }

        [Required]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Status is required."), ]
        public EventStatusEnum Status { get; set; }

        public DateTime? RegistrationStart { get; set; }

        public DateTime? RegistrationDeadline { get; set; }

        public ICollection<Registered> Registrations { get; set; } = new List<Registered>();

        public ICollection<TicketType> TicketTypes { get; set; } = new List<TicketType>();
    }
}
