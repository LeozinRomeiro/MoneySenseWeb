using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Models.Income;
using MoneySenseWeb.Models.Expense;
using MoneySenseWeb.Data.Mappings;
using MoneySenseWeb.Models.Actors;

namespace MoneySenseWeb.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Salary> Salaries { get; set; }
	public DbSet<Other> Others { get; set; }
	public DbSet<MoneySenseWeb.Models.Income.Unexpected> IncomeUnexpecteds { get; set; }
    public DbSet<MoneySenseWeb.Models.Expense.Unexpected> ExpenseUnexpecteds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Data;User ID=sa;Password=Leoadmin32@#$;Trusted_Connection=False;TrustServerCertificate=True;");
		//optionsBuilder.LogTo(Console.WriteLine);
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new SalaryMap());
        modelBuilder.ApplyConfiguration(new OtherMap());
        modelBuilder.ApplyConfiguration(new IncomeUnexpectedMap());
        modelBuilder.ApplyConfiguration(new ExpenseUnexpectedMap());
    }
}
