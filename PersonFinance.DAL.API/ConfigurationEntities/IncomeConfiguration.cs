using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    public class IncomeConfiguration : IEntityTypeConfiguration<Income>
    {
        public const string Table_name = "incomes";
        public void Configure(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid);

            builder.Property(e => e.MoneyReceived.Amount)
                   .HasColumnType(EntityDataTypes.Decimal);

            builder.Property(e => e.MoneyReceived.Corrency)
                   .HasColumnType(EntityDataTypes.SmallInt);

            builder.Property(e => e.ReceiptDate)
                   .HasColumnType(EntityDataTypes.DateTimeYtc);

            builder.Property(e => e.TypeActivity)
                   .HasColumnType(EntityDataTypes.Character_varying);
        }
    }
}
