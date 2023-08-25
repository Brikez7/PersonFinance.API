namespace PersonFinance.API.Domain.Entities
{
    public class RequestNewPerson
    {
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public RequestNewPerson(Guid personId, string name)
        {
            PersonId = personId;
            Name = name;
        }
    }
}
