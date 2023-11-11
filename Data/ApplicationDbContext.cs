using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Models.Expense;
using MoneySenseWeb.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using MoneySenseWeb.Models.Income;
using MoneySenseWeb.Models;

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
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    //optionsBuilder.UseSqlServer("");//optionsBuilder.LogTo(Console.WriteLine);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new SalaryMap());
        modelBuilder.ApplyConfiguration(new OtherMap());
        modelBuilder.ApplyConfiguration(new IncomeUnexpectedMap());
        modelBuilder.ApplyConfiguration(new ExpenseUnexpectedMap());
        modelBuilder.ApplyConfiguration(new TransactionMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
    }
}
