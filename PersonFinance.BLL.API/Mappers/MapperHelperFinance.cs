using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperFinance
    {
        public static FinanceDTO ToFinanceDTO(this Finance finance)
        {
            return new FinanceDTO(finance.Id, finance.MoneyAccountId, finance.PersonId, finance.Money);
        }
        public static Finance ToFinance(this FinanceDTO finance)
        {
            return new Finance(finance.Id, finance.MoneyAccountId, finance.PersonId, finance.Money);
        }
        public static Finance ToFinance(this RequestNewFinance finance)
        {
            return new Finance(finance.MoneyAccountId, finance.PersonId, finance.Money);
        }
    }
}
