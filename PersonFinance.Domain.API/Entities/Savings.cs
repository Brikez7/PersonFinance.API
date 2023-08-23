using PersonFinance.API.Domain.Entities.structs;

namespace PersonFinance.API.Domain.Entities
{
    public class Savings
    {
        public Guid Id { get; set; }

        public Savings(Guid id)
        {
            Id = id;
        }
        public virtual List<Finance>? Finances { get; set; }
        public virtual List<MoneyAccount>? MoneyAccounts { get; set; }
    }
}
