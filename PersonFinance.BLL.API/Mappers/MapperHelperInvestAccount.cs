using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperInvestAccount
    {
        public static InvestAccountDTO ToInvestAccountDTO(this InvestAccount investAccount)
        {
            return new InvestAccountDTO(investAccount.Id, investAccount.UserName, investAccount.DateStart, investAccount.DateEnd, investAccount.InterestRate, investAccount.Money);
        }
        public static InvestAccount ToInvestAccount(this RequestNewInvestAccount investAccount)
        {
            return new InvestAccount(investAccount.UserName, investAccount.DateStart, investAccount.DateEnd, investAccount.InterestRate, investAccount.Money);
        }
        public static InvestAccount ToInvestAccount(this InvestAccountDTO investAccount)
        {
            return new InvestAccount(investAccount.Id, investAccount.UserName, investAccount.DateStart, investAccount.DateEnd, investAccount.InterestRate, investAccount.Money);
        }
    }
}
