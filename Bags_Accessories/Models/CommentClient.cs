using Bags_Accessories.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bags_Accessories.Models
{
    public class CommentClient
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CommentTXT { get; set; }
        public int? BagID { get; set; }
        [ForeignKey("BagID")]
        public Bag Bag { get; set; }

        public int? AccessorieID { get; set; }
        [ForeignKey("AccessorieID")]
        public Accessorie Accessorie { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        public DateTime CreatedateTime { get; set; }


    }
}
