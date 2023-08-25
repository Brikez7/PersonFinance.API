using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    public class IncomeController : ControllerBase
    {
        private readonly IGenericRepository<Income> _incomeRepository;
        private readonly ILogger<IncomeController> _logger;
        public IncomeController(IGenericRepository<Income> incomeRepository, ILogger<IncomeController> logger)
        {
            _incomeRepository = incomeRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var incomes = await _incomeRepository.Get().ToArrayAsync();
            return Ok(incomes);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Income income)
        {
            var newIncome = await _incomeRepository.AddAsync(income);
            await _incomeRepository.SaveChangesAsync();
            return Ok(new Tuple<bool, Income?>(true, newIncome));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedIncome = await _incomeRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedIncome is not null)
            {
                _incomeRepository.Remove(deletedIncome);
                await _incomeRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] Income income)
        {
            var finedIncome = await _incomeRepository.Get().AnyAsync(x => x.Id == income.Id);
            if (finedIncome)
            {
                _incomeRepository.Update(income);
                await _incomeRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, Income?>(true, income));
            }
            return Ok(new Tuple<bool, Income?>(false, income));
        }
    }
}
