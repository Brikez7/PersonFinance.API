using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class BankingAccount
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string BankName { get; set; } = null!;
        public DateTimeOffset DateStart { get; set; }
        public DateTimeOffset DateEnd { get; set; }
        public decimal InterestRate { get; set; }
        public Money Money { get; set; } = null!;

        private BankingAccount() { } 
        public BankingAccount(Guid id, string userName, string bankName, DateTimeOffset dateStart, DateTimeOffset dateEnd, decimal interestRate, Money money)
        {
            Id = id;
            UserName = userName;
            BankName = bankName;
            DateStart = dateStart;
            DateEnd = dateEnd;
            InterestRate = interestRate;
            Money = money;
        }

        public BankingAccount(string userName, string bankName, DateTimeOffset dateStart, DateTimeOffset dateEnd, decimal interestRate, Money money)
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
