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

        public Contract(Guid personId, string otherPerson, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, TypeContract typeContract)
        {
            PersonId = personId;
            OtherPerson = otherPerson;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            TypeContract = typeContract;
        }

        public Contract(Guid id, Guid personId, string otherPerson, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, bool returned, DateTimeOffset? returnedDate, Money? returnedMoney, TypeContract typeContract)
        {
            Id = id;
            PersonId = personId;
            OtherPerson = otherPerson;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            Returned = returned;
            ReturnedDate = returnedDate;
            ReturnedMoney = returnedMoney;
            TypeContract = typeContract;
        }

        public virtual Person Person { get; set; } = null!;
    }
    public enum TypeContract
    {
        Credit,
        Debt,
    }
}