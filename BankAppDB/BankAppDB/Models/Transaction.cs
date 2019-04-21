using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppDB.Models
{
    public partial class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(string iban, decimal amount, DateTime timestamp)
        {
            IBAN = iban;
            Amount = amount;
            Timestamp = timestamp;
        }

        public long Id { get; set; }
        [Required]
        [StringLength(20)]
        public string IBAN { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Amount { get; set; }
        [Column(TypeName = "date")]
        public DateTime Timestamp { get; set; }

        [ForeignKey("IBAN")]
        [InverseProperty("Transaction")]
        public virtual Account IBANNavigation { get; set; }
    }
}