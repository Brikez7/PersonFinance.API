using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonFinance.API.DAL.ConfigurationEntitiesDataType;
using PersonFinance.API.Domain.Entities.structs;
using System.Linq.Expressions;

namespace PersonFinance.API.DAL.ConfigurationEntities.ConfigurationExtensions
{
    public static class MoneyExtensions
    {
        public static void OwnsOneMoney<T>(this EntityTypeBuilder<T> builder, Expression<Func<T, Money?>> fieldMoney) where T : class
        {
            builder.OwnsOne(fieldMoney,
                on =>
                {
                    on.Property(e => e.Corrency)
                      .HasColumnType(EntityDataTypes.SmallInt);

                    on.Property(e => e.Amount)
                      .HasColumnType(EntityDataTypes.Decimal);
                }
            );
        }
    }
}
