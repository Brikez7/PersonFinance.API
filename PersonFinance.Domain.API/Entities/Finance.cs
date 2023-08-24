using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Finance
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public decimal Money { get; set; }
        public Currency Currency { get; set; }

        public Finance(Guid personId, decimal money, Currency currency)
        {
            PersonId = personId;
            Money = money;
            Currency = currency;
        }

        public Finance(Guid id, Guid personId, decimal money, Currency currency)
        {
            Id = id;
            PersonId = personId;
            Money = money;
            Currency = currency;
        }

        public virtual MoneyAccount? MoneyAccount { get; set; }
        public virtual Savings? Savings { get; set; }
    }
}
