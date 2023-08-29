using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class ContractDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string OtherPerson { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public decimal InterestRate { get; set; }
        public Money MoneyCredit { get; set; }
        public bool Returned { get; set; } = false;
        public DateTimeOffset? ReturnedDate { get; set; }
        public Money? ReturnedMoney { get; set; }
        public TypeContract TypeContract { get; set; }

        public ContractDTO(Guid id, string userName, string otherPerson, DateTimeOffset receiptDate, decimal interestRate, Money moneyCredit, bool returned, DateTimeOffset? returnedDate, Money? returnedMoney, TypeContract typeContract)
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
}