using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Models.Income;

namespace MoneySenseWeb.Data.Mappings
{
    public class IncomeUnexpectedMap : IEntityTypeConfiguration<Models.Income.Unexpected>
    {
        public void Configure(EntityTypeBuilder<Models.Income.Unexpected> builder)
        {
            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
        }
    }
}
