using System.ComponentModel.DataAnnotations;

namespace EMSWebApp.Models
{
    public class Venue
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Venue name is required.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Capacity is required."), Range(1, 100000, ErrorMessage = "Capacity must be at least 1.")]
        public int? Capacity { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Contact name is required.")]
        public string ContactName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Status is required."), Range(1, 2, ErrorMessage = "Status is required.")]
        public VenueStatusEnum Status { get; set; }
    }
}