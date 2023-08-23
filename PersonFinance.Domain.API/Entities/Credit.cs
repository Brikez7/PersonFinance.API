using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Credit
    {
        public int Id { get; set; }
        public Money MoneyCredit { get; set; }
        public decimal InterestRate { get; set; }
        public bool Returned { get; set; }
        public DateTimeOffset ReturnedDate { get; set; }
        public Money ReturnedMoney { get; set; }
        public string Debtor { get; set; }

        public Credit(int id, Money moneyCredit, decimal interestRate, bool returned, DateTimeOffset returnedDate, Money returnedMoney, string debtor)
        {
            Id = id;
            MoneyCredit = moneyCredit;
            InterestRate = interestRate;
            Returned = returned;
            ReturnedDate = returnedDate;
            ReturnedMoney = returnedMoney;
            Debtor = debtor;
        }
    }
}
