using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace First_CSharp.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public int Amount { get; set; }
        [Required]
        public string ExpenseType { get; set; }

        [DisplayName("Expense Category")]
        public int FKID { get; set; }
        [ForeignKey("FKID")]
        public virtual ExpenseCategory ExpenseCategory { get; set; }

    }
}
