using System.ComponentModel.DataAnnotations;

namespace TestForSol.ViewModels
{
    public class OrderViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Number")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Date")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "ProviderId")]
        public string ProviderName { get; set; }
    }
}
