namespace PersonFinance.API.Domain.Entities
{
    public class Savings
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public Savings() { }

        public Savings(string name, Guid personId)
        {
            Name = name;
            PersonId = personId;
        }

        public Savings(Guid id, string name, Guid personId)
        {
            Id = id;
            Name = name;
            PersonId = personId;
        }

        public virtual List<Finance>? Finances { get; set; } = new List<Finance>();
        public virtual List<MoneyAccount>? MoneyAccounts { get; set; } = new List<MoneyAccount>();
        public virtual Person? Person { get; set; }
    }
}
