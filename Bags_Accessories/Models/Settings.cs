using System.ComponentModel.DataAnnotations;

namespace Bags_Accessories.Models
{
    public class Settings
    {
        [Key]
        public string SettingName { get; set; }
        public string SettingValue { get; set; }
    }
}
