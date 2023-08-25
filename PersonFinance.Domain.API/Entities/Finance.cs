using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Finance
    {
        public Guid Id { get; set; }
        public Guid? MoneyAccountId { get; set; } = null;
        public Guid? PersonId { get; set; } = null;
        public Money Money { get; set; } = null!;
        public Finance() { }

        public Finance(Guid? accountId, Guid? savingsId, Money money)
        {
            MoneyAccountId = accountId;
            PersonId = savingsId;
            Money = money;
        }

        public Finance(Guid id, Guid? accountId, Guid? savingsId, Money money)
        {
            Id = id;
            MoneyAccountId = accountId;
            PersonId = savingsId;
            Money = money;
        }

        public virtual MoneyAccount? MoneyAccount { get; set; }
        public virtual Person? Person { get; set; }
    }
}
