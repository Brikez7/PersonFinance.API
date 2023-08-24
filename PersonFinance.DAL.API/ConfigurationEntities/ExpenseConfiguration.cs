using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public const string Table_name = "expenses";
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid);

            builder.Property(e => e.Category)
                   .HasColumnType(EntityDataTypes.Character_varying);

            builder.Property(e => e.SubCategory)
                   .HasColumnType(EntityDataTypes.Character_varying);

            builder.Property(e => e.ExpenditureDate)
                   .HasColumnType(EntityDataTypes.DateTimeYtc);

            builder.Property(e => e.MoneySpent.Amount)
                   .HasColumnType (EntityDataTypes.Decimal);

            builder.Property(e => e.MoneySpent.Corrency)
                   .HasColumnType(EntityDataTypes.SmallInt);

            builder.Property(e => e.PurposeSpending)
                   .HasColumnType(EntityDataTypes.Character_varying);
        }
    }
}
