using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MoneySenseWeb.Models;

namespace MoneySenseWeb.Data.Mappings
{
	public class CategoryMap : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.ToTable("Category");
			
			builder.HasKey(x => x.Id);
			
			builder.Property(x=>x.Id)
				.ValueGeneratedOnAdd()
				.UseIdentityColumn();

			builder.Property(x => x.Title)
				.IsRequired()
				.HasColumnName("Title")
				.HasColumnType("NVARCAHR");

			builder.Property(x => x.Icon)
				.IsRequired()
				.HasColumnName("Icon")
				.HasColumnType("NVARCAHR");

			builder.Property(x => x.Type)
				.IsRequired()
				.HasColumnName("Type")
				.HasColumnType("NVARCAHR");
		}
	}
}
