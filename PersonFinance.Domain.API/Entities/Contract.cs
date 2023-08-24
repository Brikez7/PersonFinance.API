using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string Person { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public decimal InterestRate { get; set; }
        public Money MoneyCredit { get; set; }
        public bool Returned { get; set; }
        public DateTimeOffset? ReturnedDate { get; set; }
        public Money? ReturnedMoney { get; set; }
        public TypeContract TypeContract { get; set; }

        public Contract(string person, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, bool returned, TypeContract typeContract)
        {
            Person = person;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            Returned = returned;
            TypeContract = typeContract;
        }

        public Contract(Guid id, string person, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, bool returned, DateTimeOffset returnedDate, Money returnedMoney, TypeContract typeContract)
        {
            Id = id;
            Person = person;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            Returned = returned;
            ReturnedDate = returnedDate;
            ReturnedMoney = returnedMoney;
            TypeContract = typeContract;
        }
    }
    public enum TypeContract
    {
        Credit,
        Debt,
    }
}
