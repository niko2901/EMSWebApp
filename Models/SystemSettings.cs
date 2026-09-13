using System.Diagnostics;

namespace EMSWebApp.Models
{
    public class SystemSettings
    {
        public int Id { get; set; }
        public string Key { get; set; } = string.Empty;
        public bool IsEnabled { get; set; }
    }
}
