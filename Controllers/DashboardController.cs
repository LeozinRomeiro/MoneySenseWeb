using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Data;
using MoneySenseWeb.Models;
using System.Globalization;

namespace MoneySenseWeb.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context) => _context = context;


        public async Task<IActionResult> Index()
        {
            //Ultima semana
            DateTime StartDate = DateTime.Today.AddDays(-30);
            DateTime EndDate = DateTime.Today;

            List<Transaction> SelectedTransactions = await _context.Transactions.Include(t=>t.Category)
                .Where(y=>y.Date>=StartDate && y.Date<= EndDate)
                .Take(20)
                .ToListAsync();

            //Total de Receita
            double TotalIncome = SelectedTransactions.Where(t => t.Category.Type == "Income").Sum(t => t.Amount);
            ViewBag.TotalIncome = TotalIncome.ToString("C0");
            
            //Total de Despesa
            double TotalExpense = SelectedTransactions.Where(t => t.Category.Type == "Expense").Sum(t => t.Amount);
            ViewBag.TotalExpense = TotalExpense.ToString("C0");

            //Desfecho
            double Outcome = TotalIncome - TotalExpense;
            CultureInfo culture = CultureInfo.CreateSpecificCulture("pt-BR");
            culture.NumberFormat.CurrencyNegativePattern = 1;
            ViewBag.Outcome = String.Format(culture, "{0:C0}", Outcome);

            //Grafico pizza
            ViewBag.DoughnutChartData = SelectedTransactions.Where(x => x.Category.Type == "Expense")
                .GroupBy(x => x.Category.CategoryId)
                .Select(x => new
                {
                    categoryTitleWithIcon = x.First().Category.Icon + " " + x.First().Category.Title,
                    amount = x.Sum(t => t.Amount),
                    formattedValue = x.Sum(t => t.Amount).ToString("C0")

                })
                .OrderByDescending(x=>x.amount)
                .ToList();

            //Spline Chart
            List<SplineChartData> IncomeSummary = SelectedTransactions
                .Where(t => t.Category.Type == "Income")
                .GroupBy(t => t.Date)
                .Select(t => new SplineChartData
                {
                    day = t.First().Date.ToString("dd-MMM"),
                    income = t.Sum(t => t.Amount)
                })
                .ToList();
            
            List<SplineChartData> ExpenseSummary = SelectedTransactions
                .Where(t => t.Category.Type == "Expense")
                .GroupBy(t => t.Date)
                .Select(t => new SplineChartData
                {
                    day = t.First().Date.ToString("dd-MMM"),
                    expense = t.Sum(t => t.Amount)
                })
                .ToList();

                string[] Last7Days = Enumerable.Range(0, 30)
                    .Select(i => StartDate.AddDays(i).ToString("dd-MMM"))
                    .ToArray();

                ViewBag.SplineChartData = from day in Last7Days
                                            join income in IncomeSummary on day equals income.day into dayIncomeJoined
                                            from income in dayIncomeJoined.DefaultIfEmpty()
                                            join expense in ExpenseSummary on day equals expense.day into expenseJoined
                                            from expense in expenseJoined.DefaultIfEmpty()
                                            select new
                                            {
                                                day = day,
                                                income = income == null ? 0 : income.income,
                                                expense = expense == null ? 0 : expense.expense,
                                            };

            //Trasações recentes
            ViewBag.RecentTransactions = await _context.Transactions
                .Include(i => i.Category)
                .OrderByDescending(j => j.Date)
                .Take(5)
                .ToListAsync();

            return View();
        }
    }

    public class SplineChartData
    {
        public string day;
        public double income;
        public double expense;

    }
}
