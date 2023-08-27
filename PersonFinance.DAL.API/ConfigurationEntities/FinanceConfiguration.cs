using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntities.ConfigurationExtensions;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    public class FinanceConfiguration : IEntityTypeConfiguration<Cash>
    {
        public const string Table_name = "cashes";
        public void Configure(EntityTypeBuilder<Cash> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid);
        
            builder.Property(e => e.UserName) 
                   .HasColumnType(EntityDataTypes.Character_varying);

            builder.OwnsOneMoney(e => e.Money);
        }
    }
}
