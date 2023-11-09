using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Models.Income;
using MoneySenseWeb.Models.Expense;

namespace MoneySenseWeb.Data.Mappings
{
    public class OtherMap : IEntityTypeConfiguration<Other>
    {
        public void Configure(EntityTypeBuilder<Other> builder)
        {
            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
        }
    }
}
