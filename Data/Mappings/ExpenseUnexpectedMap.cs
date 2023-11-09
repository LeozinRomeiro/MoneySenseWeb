using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MoneySenseWeb.Data.Mappings
{
    public class ExpenseUnexpectedMap : IEntityTypeConfiguration<Models.Expense.Unexpected>
    {
        public void Configure(EntityTypeBuilder<Models.Expense.Unexpected> builder)
        {
            builder.Property(x => x.Value)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
        }
    }
}
