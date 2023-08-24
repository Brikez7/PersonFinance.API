namespace PersonFinance.API.Domain.Entities.structs
{
    public struct Money
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }

        public Money(decimal amount, Currency corrency)
        {
            Amount = amount;
            Currency = corrency;
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
