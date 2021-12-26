using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsMicroservice.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }
        public string Account_Type { get; set; }
        public int CustomerId { get; set; } 
        [DataType(DataType.DateTime)]
        public DateTime AccountCreationDate { get; set; }
        public double Balance_Amount { get; set; }
    }
}
