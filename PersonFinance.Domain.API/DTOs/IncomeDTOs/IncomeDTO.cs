using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class IncomeDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public Money MoneyReceived { get; set; } = null!;
        public DateTimeOffset ReceiptDate { get; set; }
        public string TypeActivity { get; set; } = null!;

        public IncomeDTO(Guid id, string userName, Money moneyReceived, DateTimeOffset receiptDate, string typeActivity)
        {
            Id = id;
            UserName = userName;
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
        }
    }
}
