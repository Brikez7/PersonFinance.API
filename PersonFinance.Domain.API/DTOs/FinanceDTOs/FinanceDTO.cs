using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class FinanceDTO
    {
        public Guid Id { get; set; }
        public Guid? MoneyAccountId { get; set; } = null;
        public Guid? PersonId { get; set; } = null;
        public Money Money { get; set; } = null!;

        public FinanceDTO(Guid id, Guid? moneyAccountId, Guid? personId, Money money)
        {
            Id = id;
            MoneyAccountId = moneyAccountId;
            PersonId = personId;
            Money = money;
        }
    }
}
