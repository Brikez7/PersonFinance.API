namespace PersonFinance.API.Domain.Entities.structs
{
    public class Money
    {
        public decimal Amount { get; set; }
        public Currency Corrency { get; set; }
        public Money(decimal amount, Currency corrency)
        {
            Amount = amount;
            Corrency = corrency;
        }
    }
    public enum Currency
    {
        RUB,
        BYN,
        USD,
        EUR,
        CNY
    }
}
