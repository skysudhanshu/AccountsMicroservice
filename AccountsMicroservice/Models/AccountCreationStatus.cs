using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsMicroservice.Models
{
    public class AccountCreationStatus
    {
        [Key]
        public int AccountId { get; set; }
        public string Message { get; set; }

       
    }
}
