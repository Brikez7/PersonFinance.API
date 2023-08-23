using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Finance
    {
        public Guid Id { get; set; }
        public Money Money { get; set; }

        public Finance(Guid id, Money money)
        {
            Id = id;
            Money = money;
        }
    }
}
