using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AccountsMicroservice.Models
{
    public class Statement
    {
        [Key]
        public int AccountId { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime TransactionDate { get; set; }
        public string ChqOrRefno { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ValueDate { get; set; }
        public double Withdrawal { get; set; }
        public double Deposit { get; set; }
        public double ClosingBalance { get; set; }
    }
}
