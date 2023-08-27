using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Income
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public Money MoneyReceived { get; set; } = null!;
        public DateTimeOffset ReceiptDate { get; set; }
        public string TypeActivity { get; set; } = null!;

        private Income() { }
        public Income(Money moneyReceived, DateTimeOffset receiptDate, string typeActivity, string userName)
        {
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
            UserName = userName;
        }

        public Income(Guid id, Money moneyReceived, DateTimeOffset receiptDate, string typeActivity, string userName)
        {
            Id = id;
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
            UserName = userName;
        }
    }
}
