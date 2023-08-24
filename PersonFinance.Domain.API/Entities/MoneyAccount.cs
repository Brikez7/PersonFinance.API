namespace PersonFinance.API.Domain.Entities
{
    public class MoneyAccount
    {
        public Guid Id { get; set; }
        public Guid SavingsId { get; set; }
        public Guid NumberBank { get; set; }
        public string Bank { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public MoneyAccount() { }
        public MoneyAccount(Guid number, string bank, TypeAccount typeAccount, Guid savingsId)
        {
            NumberBank = number;
            Bank = bank;
            TypeAccount = typeAccount;
            SavingsId = savingsId;
        }

        public MoneyAccount(Guid id, Guid number, string bank, TypeAccount typeAccount, Guid savingsId)
        {
            Id = id;
            NumberBank = number;
            Bank = bank;
            TypeAccount = typeAccount;
            SavingsId = savingsId;
        }
        public virtual List<Finance>? Finances { get; set; } = new List<Finance>();
        public virtual Savings? Savings { get; set; }
    }
    public enum TypeAccount 
    {
        Invest,
        Banking
    }
}
