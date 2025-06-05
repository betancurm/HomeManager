using HomeManagment.Domain.Entities;
using HomeManagment.Infrastructure.Identity;
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
        builder.HasOne(e => e.Category)
            .WithMany()
            .HasForeignKey(e => e.CategoryId);
        builder.Property(e => e.ApplicationUserId)
               .HasColumnName("ApplicationUserId")
               .IsRequired();

        // 2. Definir la relación con ApplicationUser usando esa columna
        builder.HasOne<ApplicationUser>()
               .WithMany(u => u.Expenses)
               .HasForeignKey(i =>i.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);
    }
}
