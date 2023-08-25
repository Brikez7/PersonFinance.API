namespace PersonFinance.API.Domain.Entities
{
    public class Person
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        private Person() { }
        public Person(string name)
        {
            Name = name;
        }

        public Person(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public virtual List<Contract> Contracts { get; set; } = new List<Contract>();
        public virtual List<Expense> Expenses { get; set; } = new List<Expense>();
        public virtual List<Income> Incomes { get; set; } = new List<Income>();
        public virtual List<Finance> Finances { get; set; } = new List<Finance>();
        public virtual List<MoneyAccount> MoneyAccounts { get; set; } = new List<MoneyAccount>();
    }
}
