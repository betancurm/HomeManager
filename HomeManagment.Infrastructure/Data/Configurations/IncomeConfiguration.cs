using HomeManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HomeManagment.Infrastructure.Data.Configurations;
public class IncomeConfiguration : IEntityTypeConfiguration<Income>
{
    public void Configure(EntityTypeBuilder<Income> builder)
    {
        builder.ToTable("Incomes");
        builder.HasKey(i => i.Id);
        builder.Property(i => i.Amount).HasPrecision(18,2).IsRequired();
        builder.Property(i => i.Description).HasMaxLength(100);
        builder.Property(i => i.Date).IsRequired();
        builder.Property(i => i.UserId).IsRequired();
        builder.HasOne(i => i.Category)
            .WithMany()
            .HasForeignKey(i => i.CategoryId);
          
    }
}
