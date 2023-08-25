namespace PersonFinance.API.Domain.Entities
{
    public class MoneyAccount
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string NumberBank { get; set; }
        public string Bank { get; set; }
        public TypeAccount TypeAccount { get; set; }
        private MoneyAccount() { }
        public MoneyAccount(string number, string bank, TypeAccount typeAccount, Guid personId)
        {
            NumberBank = number;
            Bank = bank;
            TypeAccount = typeAccount;
            PersonId = personId;
        }

        public MoneyAccount(Guid id, string number, string bank, TypeAccount typeAccount, Guid personId)
        {
            Id = id;
            NumberBank = number;
            Bank = bank;
            TypeAccount = typeAccount;
            PersonId = personId;
        }
        public virtual List<Finance> Finances { get; set; } = new List<Finance>();
        public virtual Person Person { get; set; } = null!;
    }
    public enum TypeAccount 
    {
        Invest,
        Banking
    }
}
