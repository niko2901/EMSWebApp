using System.ComponentModel.DataAnnotations;

namespace EMSWebApp.Models
{
    public class YearLevel
    {
        [Key]
        public int YearLevelId { get; set; }
        [Required]
        public string Level { get; set; } = string.Empty;
    }
}
