using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.BLL.Mappers;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;
using PersonFinance.API.Domain.Response;

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
            var moneyAccounts = await _moneyAccountRepository.Get().Select(x => x.ToMoneyAccountDTO()).ToArrayAsync();
            return Ok(new StandardResponse<MoneyAccountDTO[]>(moneyAccounts));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RequestNewMoneyAccount moneyAccount)
        {
            var newMoneyAccount = await _moneyAccountRepository.AddAsync(moneyAccount.ToMoneyAccount());
            await _moneyAccountRepository.SaveChangesAsync();
            return Ok(new StandardResponse<MoneyAccountDTO>(newMoneyAccount.ToMoneyAccountDTO()));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedMoneyAccount = await _moneyAccountRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedMoneyAccount is not null)
            {
                _moneyAccountRepository.Remove(deletedMoneyAccount);
                await _moneyAccountRepository.SaveChangesAsync();
                return Ok(new StandardResponse<bool>(true));
            }

            return Ok(new StandardResponse<bool>(false, ServiceCode.ErrorDelete));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] MoneyAccountDTO moneyAccount)
        {
            var finedMoneyAccount = await _moneyAccountRepository.Get().AnyAsync(x => x.Id == moneyAccount.Id);
            if (finedMoneyAccount)
            {
                _moneyAccountRepository.Update(moneyAccount.ToMoneyAccount());
                await _moneyAccountRepository.SaveChangesAsync();
                return Ok(new StandardResponse<MoneyAccountDTO>(moneyAccount));
            }
            return Ok(new StandardResponse<MoneyAccountDTO>(moneyAccount, ServiceCode.ErrorUpdate));
        }
    }
}
