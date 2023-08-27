using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewInvestAccount
    {
        public string UserName { get; set; } = null!;
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public decimal InterestRate { get; set; }
        public Money Money { get; set; } = null!;

        public RequestNewInvestAccount(string userName, DateTimeOffset dateStart, DateTimeOffset dateEnd, decimal interestRate, Money money)
        {
            UserName = userName;
            DateStart = dateStart;
            DateEnd = dateEnd;
            InterestRate = interestRate;
            Money = money;
        }
    }
}
