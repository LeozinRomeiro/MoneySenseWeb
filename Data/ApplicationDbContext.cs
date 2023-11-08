using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneySense.Models.Income;
using MoneySense.Models.Expense;

namespace MoneySenseWeb.Data;

public class ApplicationDbContext : IdentityDbContext
{
	public DbSet<Salary> Salaries { get; set; }
	public DbSet<Other> Others { get; set; }
	public DbSet<MoneySense.Models.Income.Unexpected> IncomeUnexpecteds { get; set; }
    public DbSet<MoneySense.Models.Expense.Unexpected> ExpenseUnexpecteds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Data;User ID=sa;Password=Leoadmin32@#$;Trusted_Connection=False;TrustServerCertificate=True;");
		//optionsBuilder.LogTo(Console.WriteLine);
	}

    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    //modelBuilder.ApplyConfiguration(new PriceMap());
    //    //modelBuilder.ApplyConfiguration(new FillingStationMap());
    //    //modelBuilder.ApplyConfiguration(new FuelMap());
    //}
}
