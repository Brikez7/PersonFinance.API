namespace PersonFinance.API.Domain.Entities
{
    public class MoneyAccountDTO
    {
        public Guid Id { get; set; }
        public Guid SavingsId { get; set; }
        public string NumberBank { get; set; }
        public string Bank { get; set; }
        public TypeAccount TypeAccount { get; set; }

        public MoneyAccountDTO(Guid id, Guid savingsId, string numberBank, string bank, TypeAccount typeAccount)
        {
            Id = id;
            SavingsId = savingsId;
            NumberBank = numberBank;
            Bank = bank;
            TypeAccount = typeAccount;
        }
    }
}
