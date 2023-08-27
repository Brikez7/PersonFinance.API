using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewBankingAccount
    {
        public string UserName { get; set; } = null!;
        public string BankName { get; set; } = null!;
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public decimal InterestRate { get; set; }
        public Money Money { get; set; } = null!;

        public RequestNewBankingAccount(string userName, string bankName, DateTimeOffset dateStart, DateTimeOffset dateEnd, decimal interestRate, Money money)
        {
            UserName = userName;
            BankName = bankName;
            DateStart = dateStart;
            DateEnd = dateEnd;
            InterestRate = interestRate;
            Money = money;
        }
    }
}
