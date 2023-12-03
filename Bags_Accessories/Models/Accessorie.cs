using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bags_Accessories.Models
{
    public class Accessorie
    {
        public int ID { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public string ImageName { get; set; }
        [NotMapped]
        public IFormFile ImageFile { set; get; }
       
    }
}
