using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Finance
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Money Money { get; set; }

        public Finance(Guid id, Guid personId, Money money)
        {
            Id = id;
            PersonId = personId;
            Money = money;
        }

        public virtual MoneyAccount? MoneyAccount { get; set; }
        public virtual Savings? Savings { get; set; }
    }
}
