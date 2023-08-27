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
    public class BankingAccountController : ControllerBase
    {
        private readonly IGenericRepository<BankingAccount> _bankingAccountRepository;
        private readonly ILogger<BankingAccountController> _logger;
        public BankingAccountController(IGenericRepository<BankingAccount> bankingAccountRepository, ILogger<BankingAccountController> logger)
        {
            _bankingAccountRepository = bankingAccountRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var bankingAccounts = await _bankingAccountRepository.Get().Select(x => x.ToBankingAccountDTO()).ToArrayAsync();
            return Ok(new StandardResponse<BankingAccountDTO[]>(bankingAccounts));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RequestNewBankingAccount bankingAccount)
        {
            var newBankingAccount = await _bankingAccountRepository.AddAsync(bankingAccount.ToBankingAccount());
            await _bankingAccountRepository.SaveChangesAsync();
            return Ok(new StandardResponse<BankingAccountDTO>(newBankingAccount.ToBankingAccountDTO()));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedBankingAccount = await _bankingAccountRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedBankingAccount is not null)
            {
                _bankingAccountRepository.Remove(deletedBankingAccount);
                await _bankingAccountRepository.SaveChangesAsync();
                return Ok(new StandardResponse<bool>(true));
            }

            return Ok(new StandardResponse<bool>(false, ServiceCode.ErrorDelete));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] BankingAccountDTO bankingAccount)
        {
            var finedBankingAccount = await _bankingAccountRepository.Get().AnyAsync(x => x.Id == bankingAccount.Id);
            if (finedBankingAccount)
            {
                _bankingAccountRepository.Update(bankingAccount.ToBankingAccount());
                await _bankingAccountRepository.SaveChangesAsync();
                return Ok(new StandardResponse<BankingAccountDTO>(bankingAccount));
            }
            return Ok(new StandardResponse<BankingAccountDTO>(bankingAccount, ServiceCode.ErrorUpdate));
        }
    }
}
