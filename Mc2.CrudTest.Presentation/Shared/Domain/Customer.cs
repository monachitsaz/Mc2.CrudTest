using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Domain
{
    public class Customer
    {
       
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [NotMapped]
        public string PhoneNumber { get; set; }

        public int CountryCode { get; set; }

        public ulong NationalNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string BankAccountNumber { get; set; }

       
    }
}
