using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace comp4976_assignment1.Models
{
    public class Donations
    {
        [Key]
        public int TransId { get; set; }

        public DateTime Date { get; set; }

        [ForeignKey("ContactList")]
        public int AccountNo { get; set; }
        public virtual ContactList? ContactList { get; set; }

        [ForeignKey("TransactionType")]
        public int TransactionTypeId { get; set; }
        public virtual TransactionType? TransactionType { get; set; }

        public float Amount { get; set; }

    
        [ForeignKey("PaymentMethod")]
        public int PaymentMethodId { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }

        [StringLength(200)]
        public string? Notes { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        public string? CreatedBy { get; set; }

        public string? ModifiedBy { get; set; }
    }
}