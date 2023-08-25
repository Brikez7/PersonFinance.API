using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class FinanceDTO
    {
        public Guid Id { get; set; }
        public Guid? MoneyAccountId { get; set; } = null;
        public Guid? SavingsId { get; set; } = null;
        public Money Money { get; set; } = null!;

        public FinanceDTO(Guid id, Guid? moneyAccountId, Guid? savingsId, Money money)
        {
            Id = id;
            MoneyAccountId = moneyAccountId;
            SavingsId = savingsId;
            Money = money;
        }
    }
}
