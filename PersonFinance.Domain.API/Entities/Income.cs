using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Income
    {
        public Guid Id { get; set; }
        public Currency Currency { get; set; }
        public decimal MoneyReceived { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public string TypeActivity { get; set; }

        public Income(decimal moneyReceived, DateTimeOffset receiptDate, string typeActivity, Currency currency)
        {
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
            Currency = currency;
        }

        public Income(Guid id, decimal moneyReceived, DateTimeOffset receiptDate, string typeActivity, Currency currency)
        {
            Id = id;
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
            Currency = currency;
        }
    }
}
