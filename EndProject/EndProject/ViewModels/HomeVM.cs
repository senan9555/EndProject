using EndProject.Models;
using System.Collections.Generic;

namespace EndProject.ViewModels
{
    public class HomeVM
    {
        public List<Income> Incomes { get; set; }
        public List<Expense> Expenses { get; set; }
        public List<Wage> Wages { get; set; }
    }
}
