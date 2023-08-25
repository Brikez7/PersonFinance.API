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
    public class ExpenseController : ControllerBase
    {
        private readonly IGenericRepository<Expense> _expenseRepository;
        private readonly ILogger<ExpenseController> _logger;
        public ExpenseController(IGenericRepository<Expense> expenseRepository, ILogger<ExpenseController> logger)
        {
            _expenseRepository = expenseRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var expenses = await _expenseRepository.Get().Select(x => x.ToExpenseDTO()).ToArrayAsync();
            return Ok(new StandardResponse<ExpenseDTO[]>(expenses));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RequestNewExpense expense)
        {
            var newExpense = await _expenseRepository.AddAsync(expense.ToExpense());
            await _expenseRepository.SaveChangesAsync();
            return Ok(new StandardResponse<ExpenseDTO>(newExpense.ToExpenseDTO()));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var expense = await _expenseRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (expense is not null)
            {
                _expenseRepository.Remove(expense);
                await _expenseRepository.SaveChangesAsync();
                return Ok(new StandardResponse<bool>(true));
            }

            return Ok(new StandardResponse<bool>(false));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] ExpenseDTO expense)
        {
            var finedExpense = await _expenseRepository.Get().AnyAsync(x => x.Id == expense.Id);
            if (finedExpense)
            {
                _expenseRepository.Update(expense.ToExpense());
                await _expenseRepository.SaveChangesAsync();
                return Ok(new StandardResponse<ExpenseDTO>(expense));
            }
            return Ok(new StandardResponse<ExpenseDTO>(expense, ServiceCode.ErrorUpdate));
        }
    }
}

