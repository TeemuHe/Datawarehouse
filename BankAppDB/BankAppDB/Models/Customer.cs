using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAppDB.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Account = new HashSet<Account>();
        }

        public Customer(string firstname, string lastname, int bankId)
        {
            Firstname = firstname;
            Lastname = lastname;
            BankId = bankId;
            Account = new HashSet<Account>();
        }

        public Customer(string firstname, string lastname, int bankId, ICollection<Account> accounts)
        {
            Firstname = firstname;
            Lastname = lastname;
            BankId = bankId;
            Account = accounts;
        }

        public long Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Firstname { get; set; }
        [Required]
        [StringLength(50)]
        public string Lastname { get; set; }
        public long BankId { get; set; }

        [ForeignKey("BankId")]
        [InverseProperty("Customer")]
        public virtual Bank Bank { get; set; }
        [InverseProperty("Customer")]
        public virtual ICollection<Account> Account { get; set; }
    }
}