namespace PersonFinance.API.Domain.Entities.structs
{
    public struct Money
    {
        public decimal Amount { get; set; }
        public Currency Corrency { get; set; }
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
