using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewBankingAccount
    {
        public string UserName { get; set; }
        public string BankName { get; set; } 
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public decimal InterestRate { get; set; }
        public Money Money { get; set; }

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
