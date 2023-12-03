using Bags_Accessories.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bags_Accessories.Models
{
    public class ContactUs
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        
        public int Phone { get; set; }
        [Required]
        public string CommentTXT {  get; set; }
        
        public DateTime CreatedateTime { get; set; }

        
    }
}
