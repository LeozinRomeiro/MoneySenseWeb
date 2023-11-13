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
    public DbSet<Category> Categorys { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    //optionsBuilder.UseSqlServer("");//optionsBuilder.LogTo(Console.WriteLine);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new TransactionMap());
        modelBuilder.ApplyConfiguration(new CategoryMap());
    }
}
