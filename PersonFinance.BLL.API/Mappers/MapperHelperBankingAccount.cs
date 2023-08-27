using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperBankingAccount
    {
        public static BankingAccountDTO ToBankingAccountDTO(this BankingAccount bankingAccount)
        {
            return new BankingAccountDTO(bankingAccount.Id, bankingAccount.UserName, bankingAccount.BankName, bankingAccount.DateStart, bankingAccount.DateEnd, bankingAccount.InterestRate, bankingAccount.Money);
        }
        public static BankingAccount ToBankingAccount(this RequestNewBankingAccount bankingAccount)
        {
            return new BankingAccount(bankingAccount.UserName, bankingAccount.BankName, bankingAccount.DateStart, bankingAccount.DateEnd, bankingAccount.InterestRate, bankingAccount.Money);
        }
        public static BankingAccount ToBankingAccount(this BankingAccountDTO bankingAccount)
        {
            return new BankingAccount(bankingAccount.Id, bankingAccount.UserName, bankingAccount.BankName, bankingAccount.DateStart, bankingAccount.DateEnd, bankingAccount.InterestRate, bankingAccount.Money);
        }
    }
}
