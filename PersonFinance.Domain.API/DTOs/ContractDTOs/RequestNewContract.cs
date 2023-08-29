using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewContract
    {
        public string UserName { get; set; }
        public string OtherPerson { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public decimal InterestRate { get; set; }
        public Money MoneyCredit { get; set; }
        public TypeContract TypeContract { get; set; }

        public RequestNewContract(string userName, string otherPerson, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, TypeContract typeContract)
        {
            UserName = userName;
            OtherPerson = otherPerson;
            ReceiptDate = receiptDate;
            InterestRate = interestRate;
            MoneyCredit = moneyCredit;
            TypeContract = typeContract;
        }
    }
}