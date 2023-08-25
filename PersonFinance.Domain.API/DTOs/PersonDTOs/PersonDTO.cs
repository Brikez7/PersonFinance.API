namespace PersonFinance.API.Domain.Entities
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public Guid SavingsId { get; set; }
        public string Name { get; set; }
        public PersonDTO(Guid id, Guid savingsId, string name)
        {
            Id = id;
            SavingsId = savingsId;
            Name = name;
        }
    }
}
