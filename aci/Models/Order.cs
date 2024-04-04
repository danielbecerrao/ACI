using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace aci.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public required int Amount { get; set; }
        [Required]
        [DisplayName("Product")]
        public required int ProductId { get; set; }
        public Product? Product { get; set; }
        public string? CreatedAt { get; set; }
    }
}
