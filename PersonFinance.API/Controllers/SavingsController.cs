using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    [ApiController]
    [Route("PersonFinance/v1/[controller]")]
    public class SavingsController : ControllerBase
    {
        private readonly ILogger<SavingsController> _logger;
        private readonly IGenericRepository<Savings> _savingsRepository;
        public SavingsController(ILogger<SavingsController> logger, IGenericRepository<Savings> savingsRepository)
        {
            _logger = logger;
            _savingsRepository = savingsRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var savings = await _savingsRepository.Get().ToListAsync();
            return Ok(savings);
        }

        [HttpPost("Add/{nameUser}")]
        public async Task<IActionResult> Add([FromRoute] string nameUser)
        {
            var newUser = await _savingsRepository.AddAsync(new Savings(nameUser));
            await _savingsRepository.SaveChangesAsync();
            return Ok(newUser);
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedSavings = await _savingsRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedSavings is not null)
            { 
                _savingsRepository.Remove(deletedSavings);
                await _savingsRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update/{updatedSavingsId}")]
        public async Task<IActionResult> Put([FromRoute] Guid updatedSavingsId, [FromQuery] string updatedSavingsName)
        {
            var finedSavings = await _savingsRepository.Get().FirstOrDefaultAsync(x => x.Id == updatedSavingsId);
            if (finedSavings is not null)
            {
                finedSavings.Name = updatedSavingsName;
                _savingsRepository.Update(finedSavings);
                await _savingsRepository.SaveChangesAsync();
                return Ok(new Tuple<bool,Savings>(true, finedSavings));
            }
            return Ok(new Tuple<bool, Savings?>(false, finedSavings)); 
        }
    }
}