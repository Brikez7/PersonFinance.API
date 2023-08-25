using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperExpense
    {
        public static ExpenseDTO ToExpenseDTO(this Expense expense)
        {
            return new ExpenseDTO(expense.Id, expense.PersonId, expense.Category, expense.SubCategory, expense.ExpenditureDate, expense.MoneySpent, expense.PurposeSpending);
        }
        public static Expense ToExpense(this RequestNewExpense expense)
        {
            return new Expense(expense.Category, expense.SubCategory, expense.ExpenditureDate, expense.MoneySpent, expense.PurposeSpending, expense.PersonId);
        }
        public static Expense ToExpense(this ExpenseDTO expense)
        {
            return new Expense(expense.Id, expense.Category, expense.SubCategory, expense.ExpenditureDate, expense.MoneySpent, expense.PurposeSpending, expense.PersonId);
        }
    }
}
