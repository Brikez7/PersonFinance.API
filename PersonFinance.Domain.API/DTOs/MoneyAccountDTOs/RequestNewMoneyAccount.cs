namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewMoneyAccount
    {
        public Guid SavingsId { get; set; }
        public string NumberBank { get; set; }
        public string Bank { get; set; }
        public TypeAccount TypeAccount { get; set; }

        public RequestNewMoneyAccount(Guid savingsId, string numberBank, string bank, TypeAccount typeAccount)
        {
            SavingsId = savingsId;
            NumberBank = numberBank;
            Bank = bank;
            TypeAccount = typeAccount;
        }
    }
}
