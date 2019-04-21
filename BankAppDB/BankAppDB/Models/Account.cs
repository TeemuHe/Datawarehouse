using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppDB.Models
{
    public partial class Account
    {
        public Account()
        {
            Transaction = new HashSet<Transaction>();
        }
        public Account(string iban, string name, long bankId, decimal balance)
        {
            IBAN = iban;
            Name = name;
            BankId = bankId;
            Balance = balance;
            Transaction = new HashSet<Transaction>();
        }
        public Account(string iban, string name, long bankId, decimal balance, ICollection<Transaction> transaction)
        {
            IBAN = iban;
            Name = name;
            BankId = bankId;
            Balance = balance;
            Transaction = transaction;
        }

        [Key]
        [StringLength(20)]
        public string IBAN { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public long BankId { get; set; }
        public long CustomerId { get; set; }
        [Column(TypeName = "decimal(18, 0)")]
        public decimal Balance { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Account")]
        public virtual Bank Bank { get; set; }
        [ForeignKey("CustomerId")]
        [InverseProperty("Account")]
        public virtual Customer Customer { get; set; }
        [InverseProperty("IBANNavigation")]
        public virtual ICollection<Transaction> Transaction { get; set; }
        public long Id { get; internal set; }
    }
}