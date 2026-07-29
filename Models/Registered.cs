using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EMSWebApp.Models
{
    public class Registered
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid TicketTypeId { get; set; }

        [ForeignKey(nameof(TicketTypeId))]
        public TicketType? TicketType { get; set; }

        [Required]
        public Guid EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public UserEvent? UserEvent { get; set; }

        [Required, MaxLength(150)]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress, MaxLength(100)]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; } = string.Empty;

        [Required]
        public int StatusId { get; set; }

        [ForeignKey(nameof(StatusId))]
        public RegisterStatus? RegisterStatus { get; set; }

        public DateTime RegisterDate { get; set; } = DateTime.UtcNow;

        public DateTime? CheckInDate { get; set; }
    }
}
