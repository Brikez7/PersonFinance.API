using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewCash
    {
        public string UserName { get; set; } = null!;
        public Money Money { get; set; } = null!;

        public RequestNewCash(string userName, Money money)
        {
            UserName = userName;
            Money = money;
        }
    }
}
