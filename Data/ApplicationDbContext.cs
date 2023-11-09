using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Models.Expense;
using MoneySenseWeb.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using MoneySenseWeb.Models.ActorsContext;
using MoneySenseWeb.Models.Income;

namespace MoneySenseWeb.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Salary> Salaries { get; set; }
	public DbSet<Other> Others { get; set; }
	public DbSet<Models.Income.Unexpected> IncomeUnexpecteds { get; set; }
    public DbSet<Models.Expense.Unexpected> ExpenseUnexpecteds { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		//optionsBuilder.UseSqlServer("Server=localhost,1433;Database=Data;User ID=sa;Password=Leoadmin32@#$;Trusted_Connection=False;TrustServerCertificate=True;");
		optionsBuilder.UseSqlServer("Server=LEONARDOR-PC\\SQLEXPRESS;Database=DataHomologacao;User Id=leo_sa;Password=leosa32!;Trusted_Connection=False; TrustServerCertificate=True;");
		//optionsBuilder.LogTo(Console.WriteLine);
	}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SalaryMap());
        modelBuilder.ApplyConfiguration(new OtherMap());
        modelBuilder.ApplyConfiguration(new IncomeUnexpectedMap());
        modelBuilder.ApplyConfiguration(new ExpenseUnexpectedMap());
    }
}
