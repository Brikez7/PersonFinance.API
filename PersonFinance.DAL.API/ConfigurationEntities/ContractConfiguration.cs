using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;
using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    public class ContractConfiguration : IEntityTypeConfiguration<Contract>
    {
        public const string Table_name = "contracts";
        public void Configure(EntityTypeBuilder<Contract> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid);

            builder.Property(e => e.Person)
                   .HasColumnType(EntityDataTypes.Character_varying);

            builder.Property(e => e.InterestRate)
                   .HasColumnType(EntityDataTypes.Decimal);

            builder.Property(e => e.MoneyCredit)
                   .HasConversion(p => new ValueTuple<decimal,Currency>(p.Amount, p.Corrency), p => new Money(p.Item1,p.Item2));

            builder.Property(e => e.Returned)
                   .HasColumnType(EntityDataTypes.Bool);

            builder.Property(e => e.ReturnedDate)
                   .HasColumnType(EntityDataTypes.DateTimeYtc);

            builder.Property(e => e.ReturnedMoney)
                   .HasConversion(p => p != null ? (ValueTuple<decimal, Currency>?)new ValueTuple<decimal, Currency>(p.Value.Amount, p.Value.Corrency) : null, p => p == null ? null : new Money(p.Value.Item1, p.Value.Item2));

            builder.Property(e => e.TypeContract)
                   .HasColumnType(EntityDataTypes.SmallInt);
        }
    }
}
