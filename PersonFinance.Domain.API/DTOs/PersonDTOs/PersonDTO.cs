namespace PersonFinance.API.Domain.Entities
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public PersonDTO(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public PersonDTO(Person x)
        {
        }
    }
}
