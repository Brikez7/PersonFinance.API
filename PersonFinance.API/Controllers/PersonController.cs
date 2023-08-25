using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    [Route("PersonFinance/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IGenericRepository<Person> _personsRepository;
        private readonly IGenericRepository<Savings> _savingsRepository;
        public PersonController(ILogger<PersonController> logger, IGenericRepository<Person> personsRepository, IGenericRepository<Savings> savingsRepository)
        {
            _logger = logger;
            _personsRepository = personsRepository;
            _savingsRepository = savingsRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var persons = await _personsRepository.Get().ToArrayAsync();
            return Ok(persons);
        }

        [HttpPost("Add/{newName}")]
        public async Task<IActionResult> Add([FromRoute] string newName)
        {
            var newPerson = await _personsRepository.AddAsync(new Person(newName));
            await _savingsRepository.AddAsync(new Savings() { PersonId = newPerson.Id });

            await _personsRepository.SaveChangesAsync();

            return Ok(new Tuple<bool, Person>(true, newPerson));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedPerson = await _personsRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedPerson is not null)
            {
                _personsRepository.Remove(deletedPerson);
                await _personsRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] Person updatedPerson)
        {
            var finedPerson = await _personsRepository.Get().FirstOrDefaultAsync(x => x.Id == updatedPerson.Id);
            if (finedPerson is not null)
            {
                _personsRepository.Update(updatedPerson);
                await _personsRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, Person>(true, finedPerson));
            }
            return Ok(new Tuple<bool, Person?>(false, finedPerson));
        }
    }
}
