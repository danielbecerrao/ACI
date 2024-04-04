using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace aci.Models
{
    public class Batch
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required int Amount { get; set; }
        [DisplayName("Operator")]
        public int? OperatorId { get; set; }
        public Operator? Operator { get; set; }
        public required int OrderId { get; set; }
        public Order? Order { get; set; }
        public int? GoodItems { get; set; }
        public int? BadItems { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? EndAt { get; set; }
        public int? Expenses { get; set; }
        public string? Observations { get; set; }
    }
}
