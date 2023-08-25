using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperIncome
    {
        public static IncomeDTO ToIncomeDTO(this Income income)
        {
            return new IncomeDTO(income.Id, income.PersonId, income.MoneyReceived, income.ReceiptDate, income.TypeActivity);
        }
        public static Income ToIncome(this RequestNewIncome income)
        {
            return new Income(income.MoneyReceived, income.ReceiptDate, income.TypeActivity, income.PersonId);
        }
        public static Income ToIncome(this IncomeDTO income)
        {
            return new Income(income.Id, income.MoneyReceived, income.ReceiptDate, income.TypeActivity, income.PersonId);
        }
    }
}
