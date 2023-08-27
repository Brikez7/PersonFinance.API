using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Category { get; set; } = "";
        public string SubCategory { get; set; } = "";
        public DateTimeOffset ExpenditureDate { get; set; }
        public Money MoneySpent { get; set; } = null!;
        public string PurposeSpending { get; set; } = null!;

        private Expense(){}
        public Expense(string category, string subCategory, DateTimeOffset expenditureDate, Money moneySpent, string purposeSpending, string userName)
        {
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
            UserName = userName;
        }
        public Expense(Guid id, string category, string subCategory, DateTimeOffset expenditureDate, Money moneySpent, string purposeSpending, string userName)
        {
            Id = id;
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
            UserName = userName;
        }
    }
}
