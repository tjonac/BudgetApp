using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetApp
{
    internal class Expenses
    {
        public int ID {  get; set; }
        public float Value { get; set; }
        public DateTime Date {  get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

    }
}
