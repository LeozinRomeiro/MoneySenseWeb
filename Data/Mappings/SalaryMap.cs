using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoneySenseWeb.Models.Income;

namespace MoneySenseWeb.Data.Mappings
{
    public class SalaryMap : IEntityTypeConfiguration<Salary>
    {
        public void Configure(EntityTypeBuilder<Salary> builder)
        {
            builder.Property(x=>x.Value)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
        }
    }
}
