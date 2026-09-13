using System.ComponentModel.DataAnnotations;

namespace EMSWebApp.Models
{
    public class MerchPrice
    {
        [Key]
        public int Id { get; set; }
        public string Item { get; set; } = string.Empty;
        public double Price { get; set; }
    }
}
