using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewIncome
    {
        public string UserName { get; set; }
        public Money MoneyReceived { get; set; }
        public DateTimeOffset ReceiptDate { get; set; }
        public string TypeActivity { get; set; }

        public RequestNewIncome(string userName, Money moneyReceived, DateTimeOffset receiptDate, string typeActivity)
        {
            UserName = userName;
            MoneyReceived = moneyReceived;
            ReceiptDate = receiptDate;
            TypeActivity = typeActivity;
        }
    }
}
