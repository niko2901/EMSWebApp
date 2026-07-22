using System.ComponentModel.DataAnnotations;
using EMSWebApp.Models.ModelEnums;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSWebApp.Models
{
    public class TicketType
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required]
        public int? Price { get; set; }

        [Required]
        public int? Quantity { get; set; }

        [Required]
        public Guid? EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public UserEvent? UserEvent { get; set; }

        public bool IsFree { get; set; }

        [Required]
        public AvailabilityTypeEnum Availability { get; set; }

        public ICollection<Registered> Registrations { get; set; } = new List<Registered>();
    }
}
