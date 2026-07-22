using System.ComponentModel.DataAnnotations;

namespace EMSWebApp.Models
{
    public class RegisterStatus
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
