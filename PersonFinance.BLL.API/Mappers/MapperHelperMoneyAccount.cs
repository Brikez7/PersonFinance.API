using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperMoneyAccount
    {
        public static MoneyAccountDTO ToMoneyAccountDTO(this MoneyAccount moneyAccount)
        {
            return new MoneyAccountDTO(moneyAccount.Id, moneyAccount.PersonId, moneyAccount.NumberBank, moneyAccount.Bank, moneyAccount.TypeAccount);
        }
        public static MoneyAccount ToMoneyAccount(this RequestNewMoneyAccount moneyAccount)
        {
            return new MoneyAccount(moneyAccount.NumberBank, moneyAccount.Bank, moneyAccount.TypeAccount, moneyAccount.PersonId);
        }
        public static MoneyAccount ToMoneyAccount(this MoneyAccountDTO moneyAccount)
        {
            return new MoneyAccount(moneyAccount.Id, moneyAccount.NumberBank, moneyAccount.Bank, moneyAccount.TypeAccount, moneyAccount.PersonId);
        }

    }
}
