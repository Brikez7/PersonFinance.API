using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    [ApiController]
    [Route("PersonFinance/v1/[controller]")]
    public class MoneyAccountController : ControllerBase
    {
        private readonly IGenericRepository<MoneyAccount> _moneyAccountRepository;
        private readonly ILogger<MoneyAccountController> _logger;
        public MoneyAccountController(IGenericRepository<MoneyAccount> moneyAccountRepository, ILogger<MoneyAccountController> logger)
        {
            _moneyAccountRepository = moneyAccountRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var moneyAccounts = await _moneyAccountRepository.Get().ToArrayAsync();
            return Ok(moneyAccounts);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] MoneyAccount moneyAccount)
        {
            var newMoneyAccount = await _moneyAccountRepository.AddAsync(moneyAccount);
            await _moneyAccountRepository.SaveChangesAsync();
            return Ok(new Tuple<bool, MoneyAccount?>(true, newMoneyAccount));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedMoneyAccount = await _moneyAccountRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedMoneyAccount is not null)
            {
                _moneyAccountRepository.Remove(deletedMoneyAccount);
                await _moneyAccountRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] MoneyAccount moneyAccount)
        {
            var finedMoneyAccount = await _moneyAccountRepository.Get().AnyAsync(x => x.Id == moneyAccount.Id);
            if (finedMoneyAccount)
            {
                _moneyAccountRepository.Update(moneyAccount);
                await _moneyAccountRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, MoneyAccount?>(true, moneyAccount));
            }
            return Ok(new Tuple<bool, MoneyAccount?>(false, moneyAccount));
        }
    }
}
