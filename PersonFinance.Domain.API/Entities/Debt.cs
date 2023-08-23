using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Debt
    {
        public Guid Id { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public bool Closing { get; set; }
        public DateTimeOffset ClosingDate { get; set; }
        public Money MoneyDebt { get; set; }
        public decimal InterestRete { get; set; }
        public string Creditor { get; set; }

        public Debt(Guid id, DateTimeOffset receiptDate, bool closing, DateTimeOffset closingDate, Money moneyDebt, decimal interestRate, string creditor)
        {
            Id = id;
            ReceiptDate = receiptDate;
            Closing = closing;
            ClosingDate = closingDate;
            MoneyDebt = moneyDebt;
            InterestRete = interestRate;
            Creditor = creditor;
        }
    }
}
