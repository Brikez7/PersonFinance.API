using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.DAL.ConfigurationEntities
{
    internal class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public const string Table_name = "persons";
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(Table_name);

            builder.HasKey(t => t.Id);

            builder.Property(e => e.Id)
                   .HasColumnType(EntityDataTypes.Guid);

            builder.Property(e => e.Name)
                   .HasColumnType(EntityDataTypes.Character_varying);
        }
    }
}
