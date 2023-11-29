using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bags_Accessories.Models
{
    public class CommentBag
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string CommentTXT { get; set; }
        public int BagID { get; set; }
        [ForeignKey("BagID")]
        public Bag Bag { get; set; }
        public DateTime CreatedateTime { get; set; }
       

    }
}
