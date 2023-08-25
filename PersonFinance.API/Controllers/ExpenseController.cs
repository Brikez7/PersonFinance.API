using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    [Route("PersonFinance/v1/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private readonly IGenericRepository<Expense> _expenseRepository;
        private readonly ILogger<ExpenseController> _logger;
        public ExpenseController(IGenericRepository<Expense> moneyAccountRepository, ILogger<ExpenseController> logger)
        {
            _expenseRepository = moneyAccountRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseRepository.Get().ToArrayAsync();
            return Ok(expenses);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Expense expense)
        {
            var newExpense = await _expenseRepository.AddAsync(expense);
            await _expenseRepository.SaveChangesAsync();
            return Ok(new Tuple<bool, Expense?>(true, newExpense));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var expense = await _expenseRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (expense is not null)
            {
                _expenseRepository.Remove(expense);
                await _expenseRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] Expense expense)
        {
            var finedExpense = await _expenseRepository.Get().AnyAsync(x => x.Id == expense.Id);
            if (finedExpense)
            {
                _expenseRepository.Update(expense);
                await _expenseRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, Expense?>(true, expense));
            }
            return Ok(new Tuple<bool, Expense?>(false, expense));
        }
    }
}

