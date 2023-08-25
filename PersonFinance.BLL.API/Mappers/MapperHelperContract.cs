using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperContract
    {
        public static ContractDTO ToContractDTO(this Contract contract)
        {
            return new ContractDTO(contract.Id, contract.PersonId, contract.OtherPerson, contract.ReceiptDate, contract.InterestRate, contract.MoneyCredit, contract.Returned, contract.ReturnedDate, contract.ReturnedMoney, contract.TypeContract);
        }
        public static Contract ToContract(this RequestNewContract contract)
        {
            return new Contract(contract.PersonId, contract.OtherPerson, contract.ReceiptDate, contract.InterestRate, contract.MoneyCredit, contract.TypeContract);
        }
        public static Contract ToContract(this ContractDTO contract)
        {
            return new Contract(contract.Id, contract.PersonId, contract.OtherPerson, contract.ReceiptDate, contract.InterestRate, contract.MoneyCredit, contract.Returned, contract.ReturnedDate, contract.ReturnedMoney, contract.TypeContract);
        }
    }
}
