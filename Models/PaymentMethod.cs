using System.ComponentModel.DataAnnotations;


namespace comp4976_assignment1.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }

        [StringLength(50)]
        [Required]
        public string? Name { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}