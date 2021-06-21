using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace First_CSharp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public string ExpenseType { get; set; }

    }
}
