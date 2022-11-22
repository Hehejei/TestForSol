using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestForSol.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "ProviderId")]
        public int ProviderId { get; set; }
    }
}
