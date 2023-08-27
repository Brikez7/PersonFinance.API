using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Cash
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public Money Money { get; set; } = null!;

        public Cash() { }
        public Cash(string userName, Money money)
        {
            UserName = userName;
            Money = money;
        }
        public Cash(Guid id, string userName, Money money)
        {
            Id = id;
            UserName = userName;
            Money = money;
        }
    }
}
