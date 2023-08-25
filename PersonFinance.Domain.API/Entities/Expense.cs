using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Expense
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public DateTimeOffset ExpenditureDate { get; set; }
        public Money MoneySpent { get; set; }
        public string PurposeSpending { get; set; }

        private Expense(){}

        public Expense(string category, string subCategory, DateTimeOffset expenditureDate, Money moneySpent, string purposeSpending, Guid personId)
        {
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
            PersonId = personId;
        }

        public Expense(Guid id, string category, string subCategory, DateTimeOffset expenditureDate, Money moneySpent, string purposeSpending, Guid personId    )
        {
            Id = id;
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
            PersonId = personId;
        }
        public virtual Person? Person { get; set; }
    }
}
