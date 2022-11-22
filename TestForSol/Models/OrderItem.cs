using System.ComponentModel.DataAnnotations;

namespace TestForSol.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "OrderId")]
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity")]
        public decimal Quantity { get; set; }

        [Required(ErrorMessage = "Unit")]
        public string Unit { get; set; }
    }
}
