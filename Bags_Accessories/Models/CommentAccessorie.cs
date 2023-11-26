using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bags_Accessories.Models
{
    public class CommentAccessorie
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CommentTXT {  get; set; }
        public int AccessorieID { get; set; }
        [ForeignKey("AccessorieID")]
        public Accessorie Accessorie { get; set; }
        public DateTime CreatedateTime { get; set; }
    }
}
