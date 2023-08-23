using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public string Person { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public decimal InterestRate { get; set; }
        public Money MoneyCredit { get; set; }
        public bool Returned { get; set; }
        public DateTimeOffset ReturnedDate { get; set; }
        public Money ReturnedMoney { get; set; }
        public TypeContract TypeContract { get; set; }
    }
    public enum TypeContract
    {
        Credit,
        Debt,
    }
}
