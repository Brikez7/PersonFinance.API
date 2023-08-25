namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewMoneyAccount
    {
        public Guid PersonId { get; set; }
        public string NumberBank { get; set; }
        public string Bank { get; set; }
        public TypeAccount TypeAccount { get; set; }

        public RequestNewMoneyAccount(Guid personId, string numberBank, string bank, TypeAccount typeAccount)
        {
            PersonId = personId;
            NumberBank = numberBank;
            Bank = bank;
            TypeAccount = typeAccount;
        }
    }
}
