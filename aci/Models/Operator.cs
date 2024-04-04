using System.ComponentModel.DataAnnotations;

namespace aci.Models
{
    public class Operator
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Name { get; set; }
        public ICollection<Batch>? Batches { get; }
    }
}
