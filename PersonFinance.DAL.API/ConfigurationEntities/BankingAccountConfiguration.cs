using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntities.ConfigurationExtensions;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    internal class BankingAccountConfiguration : IEntityTypeConfiguration<BankingAccount>
    {
        public const string Table_name = "banking_accounts";
        public void Configure(EntityTypeBuilder<BankingAccount> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.UserName)
                   .HasColumnType(EntityDataTypes.Character_varying);
            
            builder.Property(e => e.BankName)
                   .HasColumnType(EntityDataTypes.Character_varying);

            builder.Property(e => e.DateStart)
                   .HasColumnType(EntityDataTypes.DateTimeYtc);

            builder.Property(e => e.DateEnd)
                   .HasColumnType(EntityDataTypes.DateTimeYtc);

            builder.Property(e => e.InterestRate)
                   .HasColumnType(EntityDataTypes.Decimal);

            builder.OwnsOneMoney(e => e.Money);
        }
    }
}
