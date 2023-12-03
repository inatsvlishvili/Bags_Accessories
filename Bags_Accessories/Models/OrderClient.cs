using Bags_Accessories.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bags_Accessories.Models
{
    public class OrderClient
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string PasportID { get; set; }
        [Required]
        public int Phone { get; set; }
        [Required]
        public string Address { get; set; }
        public string CommentTXT { get; set; }
        public int? BagID { get; set; }
        [ForeignKey("BagID")]
        public Bag Bag { get; set; }

        public int? AccessorieID { get; set; }
        [ForeignKey("AccessorieID")]
        public Accessorie Accessorie { get; set; }
        public DateTime CreatedateTime { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}