using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewFinance
    {
        public Guid? MoneyAccountId { get; set; } = null;
        public Guid? PersonId { get; set; } = null;
        public Money Money { get; set; } = null!;

        public RequestNewFinance(Guid? moneyAccountId, Guid? personId, Money money)
        {
            MoneyAccountId = moneyAccountId;
            PersonId = personId;
            Money = money;
        }
    }
}
