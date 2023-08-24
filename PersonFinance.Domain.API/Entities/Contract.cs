using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string Person { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public Currency Currency { get; set; }
        public decimal InterestRate { get; set; }
        public decimal MoneyCredit { get; set; }
        public bool Returned { get; set; }
        public DateTimeOffset? ReturnedDate { get; set; }
        public decimal? ReturnedMoney { get; set; }
        public TypeContract TypeContract { get; set; }

        public Contract(string person, DateTimeOffset receiptDate, Currency currency, decimal interestRate, decimal moneyCredit, bool returned, TypeContract typeContract)
        {
            Person = person;
            ReceiptDate = receiptDate;
            Currency = currency;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            Returned = returned;
            TypeContract = typeContract;
        }

        public Contract(Guid id, string person, DateTimeOffset receiptDate, decimal interestRate, decimal moneyCredit, bool returned, DateTimeOffset? returnedDate, decimal? returnedMoney, Currency corrency, TypeContract typeContract)
        {
            Id = id;
            Person = person;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            Returned = returned;
            ReturnedDate = returnedDate;
            ReturnedMoney = returnedMoney;
            Currency = corrency;
            TypeContract = typeContract;
        }
    }
    public enum TypeContract
    {
        Credit,
        Debt,
    }
}
