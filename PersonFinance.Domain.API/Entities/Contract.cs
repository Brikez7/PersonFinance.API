using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string OtherPerson { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public decimal InterestRate { get; set; }
        public Money MoneyCredit { get; set; }
        public bool Returned { get; set; } = false;
        public DateTimeOffset? ReturnedDate { get; set; }
        public Money? ReturnedMoney { get; set; }
        public TypeContract TypeContract { get; set; }

        private Contract() { }
        public Contract(string person, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, bool returned, TypeContract typeContract, Guid personId)
        {
            OtherPerson = person;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            Returned = returned;
            TypeContract = typeContract;
            PersonId = personId;
        }

        public Contract(Guid id, string person, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, bool returned, DateTimeOffset returnedDate, Money returnedMoney, TypeContract typeContract, Guid personId)
        {
            Id = id;
            OtherPerson = person;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            Returned = returned;
            ReturnedDate = returnedDate;
            ReturnedMoney = returnedMoney;
            TypeContract = typeContract;
            PersonId = personId;
        }
        public virtual Person? Person { get; set; }
    }
    public enum TypeContract
    {
        Credit,
        Debt,
    }
}