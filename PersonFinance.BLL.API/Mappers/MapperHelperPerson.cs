using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.BLL.Mappers
{
    public static class MapperHelperPerson
    {
        public static PersonDTO ToPersonDTO(this Person person)
        {
            return new PersonDTO(person.Id, person.Name);
        }
        public static Person ToPerson(this PersonDTO person)
        {
            return new Person(person.Id, person.Name);
        }
    }
}
