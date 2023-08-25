using System.Text.Json.Serialization;

namespace PersonFinance.API.Domain.Entities
{
    public class Savings
    {
        public Guid Id { get; set; }
        public Guid PersonId { get; set; }
        public Savings() { }

        public Savings(Guid personId)
        {
            PersonId = personId;
        }

        public Savings(Guid id, Guid personId)
        {
            Id = id;
            PersonId = personId;
        }

        public virtual List<Finance>? Finances { get; set; } = new List<Finance>();
        public virtual List<MoneyAccount>? MoneyAccounts { get; set; } = new List<MoneyAccount>();
        [JsonIgnore]
        public virtual Person? Person { get; set; }
    }
}
