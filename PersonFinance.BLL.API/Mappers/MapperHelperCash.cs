using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperCash
    {
        public static CashDTO ToCashDTO(this Cash cash)
        {
            return new CashDTO(cash.Id, cash.UserName, cash.Money);
        }
        public static Cash ToCash(this CashDTO cash)
        {
            return new Cash(cash.Id, cash.UserName, cash.Money);
        }
        public static Cash ToCash(this RequestNewCash cash)
        {
            return new Cash(cash.UserName, cash.Money);
        }
    }
}
