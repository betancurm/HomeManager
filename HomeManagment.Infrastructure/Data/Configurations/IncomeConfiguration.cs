using HomeManagment.Domain.Entities;
using HomeManagment.Infrastructure.Identity;
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
        builder.HasOne(i => i.Category)
            .WithMany()
            .HasForeignKey(i => i.CategoryId);
        builder.Property(i => i.ApplicationUserId)
               .HasColumnName("ApplicationUserId")
               .IsRequired();

        // 2. Definir la relación con ApplicationUser usando esa columna
        builder.HasOne<ApplicationUser>()
               .WithMany(u => u.Incomes)
               .HasForeignKey(i =>i.ApplicationUserId)
               .OnDelete(DeleteBehavior.Cascade);

    }
}
