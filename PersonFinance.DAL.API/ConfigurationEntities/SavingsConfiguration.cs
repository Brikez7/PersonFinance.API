using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    internal class SavingsConfiguration : IEntityTypeConfiguration<Savings>
    {
        public const string Table_name = "savings_persons";
        public void Configure(EntityTypeBuilder<Savings> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid);

            builder.Property(e => e.Name)
                   .HasColumnType(EntityDataTypes.Character_varying);
        }
    }
}
