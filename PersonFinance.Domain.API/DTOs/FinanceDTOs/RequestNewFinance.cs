using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewFinance
    {
        public Guid? MoneyAccountId { get; set; } = null;
        public Guid? SavingsId { get; set; } = null;
        public Money Money { get; set; } = null!;

        public RequestNewFinance(Guid? moneyAccountId, Guid? savingsId, Money money)
        {
            MoneyAccountId = moneyAccountId;
            SavingsId = savingsId;
            Money = money;
        }
    }
}
