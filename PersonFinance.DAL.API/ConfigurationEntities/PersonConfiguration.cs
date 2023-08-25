using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities;
using System;
using System.Linq.Expressions;

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

            builder.HasOne(e => e.Savings)
                   .WithOne(e => e.Person)
                   .HasPrincipalKey<Person>( x => x.Id)
                   .HasForeignKey<Savings>(x => x.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Incomes)
                   .WithOne(e => e.Person)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Expenses)
                   .WithOne(e => e.Person)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.Contracts)
                   .WithOne(e => e.Person)
                   .HasPrincipalKey(e => e.Id)
                   .HasForeignKey(e => e.PersonId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
