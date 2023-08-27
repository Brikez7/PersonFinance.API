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
    public class InvestAccountController : ControllerBase
    {
        private readonly IGenericRepository<InvestAccount> _investAccountRepository;
        private readonly ILogger<InvestAccountController> _logger;
        public InvestAccountController(IGenericRepository<InvestAccount> investAccountRepository, ILogger<InvestAccountController> logger)
        {
            _investAccountRepository = investAccountRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var investAccounts = await _investAccountRepository.Get().Select(x => x.ToInvestAccountDTO()).ToArrayAsync();
            return Ok(new StandardResponse<InvestAccountDTO[]>(investAccounts));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RequestNewInvestAccount investAccount)
        {
            var newInvestAccount = await _investAccountRepository.AddAsync(investAccount.ToInvestAccount());
            await _investAccountRepository.SaveChangesAsync();
            return Ok(new StandardResponse<InvestAccountDTO>(newInvestAccount.ToInvestAccountDTO()));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedInvestAccount = await _investAccountRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedInvestAccount is not null)
            {
                _investAccountRepository.Remove(deletedInvestAccount);
                await _investAccountRepository.SaveChangesAsync();
                return Ok(new StandardResponse<bool>(true));
            }

            return Ok(new StandardResponse<bool>(false, ServiceCode.ErrorDelete));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] InvestAccountDTO investAccount)
        {
            var finedInvestAccount = await _investAccountRepository.Get().AnyAsync(x => x.Id == investAccount.Id);
            if (finedInvestAccount)
            {
                _investAccountRepository.Update(investAccount.ToInvestAccount());
                await _investAccountRepository.SaveChangesAsync();
                return Ok(new StandardResponse<InvestAccountDTO>(investAccount));
            }
            return Ok(new StandardResponse<InvestAccountDTO>(investAccount, ServiceCode.ErrorUpdate));
        }
    }
}
