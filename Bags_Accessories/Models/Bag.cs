using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bags_Accessories.Models
{
    public class Bag
    {
        public int ID { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "შეიყვანეთ ფასი")]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { set; get; }
        //public List<CommentBag> BagComments { get; set; }        
    }
}
