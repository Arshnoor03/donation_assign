using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace comp4976_assignment1.Models
{
    public class ContactList
    {
        [Key]
        public int AccountNo { get; set; }

        [StringLength(50)]
        [Required]
        public string? FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string? LastName { get; set; }

        [EmailAddress]
        [Required]
        public string? Email { get; set; }

        [StringLength(100)]
        [Required]
        public string? Street { get; set; }

        [StringLength(50)]
        [Required]
        public string? City { get; set; }

        [StringLength(10)]
        [Required]
        [RegularExpression(@"^([A-Za-z]\d[A-Za-z][ ]\d[A-Za-z]\d)$", ErrorMessage = "Invalid Canadian Postal Code")]
        public required string PostalCode { get; set; }

        [StringLength(50)]
        [Required]
        public string? Country { get; set; }

        public DateTime? Created { get; set; }

        public DateTime? Modified { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }

        [NotMapped] // This ensures the property is not mapped to a DB column
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
    }
}