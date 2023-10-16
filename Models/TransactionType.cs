using System.ComponentModel.DataAnnotations;


namespace comp4976_assignment1.Models
{
    public class TransactionType
    {
        [Key]
        public int TransactionTypeId { get; set; }

        [StringLength(50)]
        [Required]
        public string? Name { get; set; }

        [StringLength(200)]
        [Required]
        public string? Description { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}