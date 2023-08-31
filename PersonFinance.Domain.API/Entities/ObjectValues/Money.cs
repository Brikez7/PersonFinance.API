namespace PersonFinance.API.Domain.Entities.structs
{
    public class Money
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }
    }
}
