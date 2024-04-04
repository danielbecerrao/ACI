using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace aci.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        [Required]
        public required string Reference { get; set; }
        public ICollection<Order>? Orders { get; }
    }
}
