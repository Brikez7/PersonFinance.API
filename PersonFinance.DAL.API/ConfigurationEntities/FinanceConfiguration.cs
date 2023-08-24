using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;
using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    internal class FinanceConfiguration : IEntityTypeConfiguration<Finance>
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

            builder.Property(e => e.Money)
                   .HasConversion(p => new ValueTuple<decimal, Currency>(p.Amount, p.Corrency), p => new Money(p.Item1, p.Item2));

            builder.HasOne(e => e.Savings)
                   .WithMany(e => e.Finances)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.MoneyAccount)
                   .WithMany(e => e.Finances)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
