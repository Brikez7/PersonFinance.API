using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    public class IncomeController : ControllerBase
    {
        private readonly IGenericRepository<Income> _IncomeRepository;
        private readonly ILogger<IncomeController> _logger;
        public IncomeController(IGenericRepository<Income> moneyAccountRepository, ILogger<IncomeController> logger)
        {
            _IncomeRepository = moneyAccountRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var incomes = await _IncomeRepository.Get().ToArrayAsync();
            return Ok(incomes);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Income income)
        {
            var newIncomes = await _IncomeRepository.AddAsync(income);
            await _IncomeRepository.SaveChangesAsync();
            return Ok(new Tuple<bool, Income?>(true, newIncomes));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var Income = await _IncomeRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (Income is not null)
            {
                _IncomeRepository.Remove(Income);
                await _IncomeRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] Income income)
        {
            var finedIncome = await _IncomeRepository.Get().AnyAsync(x => x.Id == income.Id);
            if (finedIncome)
            {
                _IncomeRepository.Update(income);
                await _IncomeRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, Income?>(true, income));
            }
            return Ok(new Tuple<bool, Income?>(false, income));
        }
    }
}
