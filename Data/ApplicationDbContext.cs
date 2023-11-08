using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MoneySenseWeb.Data;

public class ApplicationDbContext : IdentityDbContext
{
	//public DbSet<Salary> Salaries { get; set; }
	//public DbSet<Other> Others { get; set; }
	public DbSet<Models.Income.Unexpected> IncomeUnexpecteds { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Data;User ID=sa;Password=Leoadmin32@#$;Trusted_Connection=False;TrustServerCertificate=True;");
		//optionsBuilder.LogTo(Console.WriteLine);
	}
}
