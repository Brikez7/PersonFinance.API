using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.BLL.Mappers;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;
using PersonFinance.API.Domain.Response;

namespace PersonFinance.API.Controllers
{
    [Route("PersonFinance/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IGenericRepository<Person> _personsRepository;
        public PersonController(ILogger<PersonController> logger, IGenericRepository<Person> personsRepository)
        {
            _logger = logger;
            _personsRepository = personsRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personsRepository.Get().Select(x => x.ToPersonDTO()).ToArrayAsync();
            return Ok(new StandardResponse<PersonDTO[]>(persons));
        }

        [HttpPost("Add/{newName}")]
        public async Task<IActionResult> Add([FromRoute] string newName)
        {
            var newPerson = await _personsRepository.AddAsync(new Person(newName));

            await _personsRepository.SaveChangesAsync();

            return Ok(new StandardResponse<PersonDTO>(newPerson.ToPersonDTO()));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedPerson = await _personsRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedPerson is not null)
            {
                _personsRepository.Remove(deletedPerson);
                await _personsRepository.SaveChangesAsync();
                return Ok(new StandardResponse<bool>(true));
            }

            return Ok(new StandardResponse<bool>(false, ServiceCode.ErrorDelete));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] PersonDTO updatedPerson)
        {
            var finedPerson = await _personsRepository.Get().FirstOrDefaultAsync(x => x.Id == updatedPerson.Id);
            if (finedPerson is not null)
            {
                _personsRepository.Update(updatedPerson.ToPerson());
                await _personsRepository.SaveChangesAsync();
                return Ok(new StandardResponse<PersonDTO>(updatedPerson));
            }
            return Ok(new StandardResponse<PersonDTO>(updatedPerson, ServiceCode.ErrorUpdate));
        }
    }
}
