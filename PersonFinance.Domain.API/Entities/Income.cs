using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Income
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Money MoneyReceived { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public string TypeActivity { get; set; }
        private Income() { }
        public Income(Money moneyReceived, DateTimeOffset receiptDate, string typeActivity, Guid personId)
        {
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
            PersonId = personId;
        }

        public Income(Guid id, Money moneyReceived, DateTimeOffset receiptDate, string typeActivity, Guid personId)
        {
            Id = id;
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
            PersonId = personId;
        }

        public virtual Person Person { get; set; } = null!;
    }
}
