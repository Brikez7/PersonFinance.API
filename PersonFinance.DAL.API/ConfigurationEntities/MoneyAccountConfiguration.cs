using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    internal class MoneyAccountConfiguration : IEntityTypeConfiguration<MoneyAccount>
    {
        public const string Table_name = "money_accounts";
        public void Configure(EntityTypeBuilder<MoneyAccount> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.PersonId)
                   .HasColumnType(EntityDataTypes.Guid);
            
            builder.Property(e => e.NumberBank)
                   .HasColumnType(EntityDataTypes.Character_varying);

            builder.Property(e => e.Bank)
                   .HasColumnType(EntityDataTypes.Character_varying);

            builder.Property(e => e.TypeAccount)
                   .HasColumnType(EntityDataTypes.SmallInt);

            builder.HasOne(e => e.Person)
                   .WithMany(e => e.MoneyAccounts)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.PersonId)
                   .OnDelete(DeleteBehavior.Cascade); 
        }
    }
}
