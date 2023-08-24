using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class MoneyAccount
    {
        public Guid Id { get; set; }
        public Guid Number { get; set; }
        public string Bank { get; set; }
        public TypeAccount TypeAccount { get; set; }
        private MoneyAccount() { }
        public MoneyAccount(Guid number, string bank, TypeAccount typeAccount)
        {
            Number = number;
            Bank = bank;
            TypeAccount = typeAccount;
        }

        public MoneyAccount(Guid id, Guid number, string bank, TypeAccount typeAccount)
        {
            Id = id;
            Number = number;
            Bank = bank;
            TypeAccount = typeAccount;
        }
        public virtual List<Finance>? Finances { get; set; } = new List<Finance>();
    }
    public enum TypeAccount 
    {
        Invest,
        Banking
    }
}
