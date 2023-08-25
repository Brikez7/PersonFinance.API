using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntities.Exstentionses;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    public class FinanceConfiguration : IEntityTypeConfiguration<Finance>
    {
        public const string Table_name = "finances";
        public void Configure(EntityTypeBuilder<Finance> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid);
        
            builder.Property(e => e.PersonId) 
                   .HasColumnType(EntityDataTypes.Guid);

            builder.Property(e => e.MoneyAccountId)
                   .HasColumnType(EntityDataTypes.Guid);

            builder.OwnsOneMoney(e => e.Money);

            builder.HasOne(e => e.Person)
                   .WithMany(e => e.Finances)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.PersonId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MoneyAccount)
                   .WithMany(e => e.Finances)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.MoneyAccountId)
                   .IsRequired(false)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
