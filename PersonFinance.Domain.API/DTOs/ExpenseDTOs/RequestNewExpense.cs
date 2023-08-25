using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewExpense
    {
        public Guid PersonId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public DateTimeOffset ExpenditureDate { get; set; }
        public Money MoneySpent { get; set; }
        public string PurposeSpending { get; set; }

        public RequestNewExpense(Guid personId, string category, string subCategory, DateTimeOffset expenditureDate, Money moneySpent, string purposeSpending)
        {
            PersonId = personId;
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
        }
    }
}
