using HomeManagment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HomeManagment.Infrastructure.Data.Configurations;
public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
{
    public void Configure(EntityTypeBuilder<Expense> builder)
    {
        builder.ToTable("Expenses");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Amount).HasPrecision(18,2).IsRequired();
        builder.Property(e => e.Description).HasMaxLength(100);
        builder.Property(e => e.Date).IsRequired();
        builder.Property(e => e.UserId).IsRequired();
        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId);
    }
}
