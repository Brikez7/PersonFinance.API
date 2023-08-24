using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class MoneyAccount
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Bank { get; set; }
        public TypeAccount TypeAccount { get; set; }
        public MoneyAccount(Guid id, string number, string bank, TypeAccount typeAccount)
        {
            Id = id;
            Number = number;
            Bank = bank;
            TypeAccount = typeAccount;
        }
        public virtual List<Finance> Finances { get; set; } = new List<Finance>();
    }
    public enum TypeAccount 
    {
        Invest,
        Banking
    }
}
