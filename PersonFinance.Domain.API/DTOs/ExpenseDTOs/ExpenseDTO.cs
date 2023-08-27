using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class ExpenseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Category { get; set; } = "";
        public string SubCategory { get; set; } = "";
        public DateTimeOffset ExpenditureDate { get; set; }
        public Money MoneySpent { get; set; } = null!;
        public string PurposeSpending { get; set; } = null!;

        public ExpenseDTO(Guid id, string userName, string category, string subCategory, DateTimeOffset expenditureDate, Money moneySpent, string purposeSpending)
        {
            Id = id;
            UserName = userName;
            Category = category;
            SubCategory = subCategory;
            ExpenditureDate = expenditureDate;
            MoneySpent = moneySpent;
            PurposeSpending = purposeSpending;
        }
    }
}
