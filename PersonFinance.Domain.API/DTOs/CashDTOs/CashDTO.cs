using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class CashDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public Money Money { get; set; } = null!;

        public CashDTO(Guid id, string userName, Money money)
        {
            Id = id;
            UserName = userName;
            Money = money;
        }
    }
}
