using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Savings
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Savings(string name)
        {
            Name = name;
        }

        public Savings(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual List<Finance> Finances { get; set; } = new List<Finance>();
        public virtual List<MoneyAccount> MoneyAccounts { get; set; } = new List<MoneyAccount>();
    }
}
