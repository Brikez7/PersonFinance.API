using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Income
    {
        public Guid Id { get; set; }
        public Money MoneyReceived { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public string TypeActivity { get; set; }

        public Income(Guid id, Money moneyReceived, DateTimeOffset receiptDate, string typeActivity)
        {
            Id = id;
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
        }
    }
}
