using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public DateTimeOffset ExpenditureDate { get; set; }
        public Currency Currency { get; set; }
        public decimal MoneySpent { get; set; }
        public string PurposeSpending { get; set; }

        public Expense(string category, string subCategory, DateTimeOffset expenditureDate, Currency currency, decimal moneySpent, string purposeSpending)
        {
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            Currency = currency;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
        }

        public Expense(Guid id, string category, string subCategory, DateTimeOffset expenditureDate, Currency currency, decimal moneySpent, string purposeSpending)
        {
            Id = id;
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            Currency = currency;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
        }
    }
}
