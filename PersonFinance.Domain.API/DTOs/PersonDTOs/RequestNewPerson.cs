namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewPerson
    {
        public Guid SavingsId { get; set; }
        public string Name { get; set; }
        public RequestNewPerson(Guid savingsId, string name)
        {
            SavingsId = savingsId;
            Name = name;
        }
    }
}
