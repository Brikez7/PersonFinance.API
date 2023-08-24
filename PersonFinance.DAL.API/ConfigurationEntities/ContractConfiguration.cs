using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntities.Exstentionses;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

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

            builder.OwnsOneMoney(e => e.MoneyCredit);

            builder.Property(e => e.Returned)
                   .HasColumnType(EntityDataTypes.Bool);

            builder.Property(e => e.ReturnedDate)
                   .HasColumnType(EntityDataTypes.DateTimeYtc);

            builder.OwnsOneMoney(e => e.ReturnedMoney);

            builder.Property(e => e.TypeContract)
                   .HasColumnType(EntityDataTypes.SmallInt);
        }
    }
}