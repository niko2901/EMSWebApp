using System.ComponentModel.DataAnnotations;

namespace EMSWebApp.Models
{
    public class Vote
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        // Membership Questions
        [Required]
        public int? MFeeQ1 { get; set; }
        [Required]
        public int? MFeeQ2 { get; set; }

        // Merch questions
            // windbreaker
        [Required]
        public int? WindQ1 { get; set; }

        [Required]
        public int? WindQ2 { get; set; }

            // hoodie
        [Required]
        public int? HoodieQ1 { get; set; }

        [Required]
        public int? HoodieQ2 { get; set; }

            // tshirt
        [Required]
        public int? TshirtQ1 { get; set; }

        [Required]
        public int? TshirtQ2 { get; set; }

            // polo
        [Required]
        public int? PoloShirtQ1 { get; set; }

        [Required]
        public int? PoloShirtQ2 { get; set; }

            // Id nonreversible
        [Required]
        public int? IdnonRevQ1 { get; set; }

        [Required]
        public int? IdnonRevQ2 { get; set; }

            // Id reversible
        [Required]
        public int? IdRevQ1 { get; set; }

        [Required]
        public int? IdRevQ2 { get; set; }

            // Mouse Pad
        [Required]
        public int? MousePadQ1 { get; set; }

        [Required]
        public int? MousePadQ2 { get; set; }

            // Cap
        [Required]
        public int? CapQ1 { get; set; }

        [Required]
        public int? CapQ2 { get; set; }

        //CBL Questions
        [Required]
        public int? CBLQ1 { get; set; }
        [Required]
        public int? CBLQ2 { get; set; }
    }
}
