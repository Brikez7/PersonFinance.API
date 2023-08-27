using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Contract
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string OtherPerson { get; set; } = null!;
        public DateTimeOffset ReceiptDate { get; set; }
        public decimal InterestRate { get; set; }
        public Money MoneyCredit { get; set; } = null!;
        public bool Returned { get; set; } = false;
        public DateTimeOffset? ReturnedDate { get; set; }
        public Money? ReturnedMoney { get; set; }
        public TypeContract TypeContract { get; set; }

        private Contract() { }
        public Contract(string userName, string otherPerson, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, TypeContract typeContract)
        {
            UserName = userName;
            OtherPerson = otherPerson;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            TypeContract = typeContract;
        }

        public Contract(Guid id, string userName, string otherPerson, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, bool returned, DateTimeOffset? returnedDate, Money? returnedMoney, TypeContract typeContract)
        {
            Id = id;
            UserName = userName;
            OtherPerson = otherPerson;
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