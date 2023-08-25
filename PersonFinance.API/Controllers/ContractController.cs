using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    [Route("PersonFinance/v1/[controller]")]
    [ApiController]
    public class ContractController : ControllerBase
    {
        private readonly IGenericRepository<Contract> _contractRepository;
        private readonly ILogger<ContractController> _logger;
        public ContractController(IGenericRepository<Contract> contractRepository, ILogger<ContractController> logger)
        {
            _contractRepository = contractRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var contracts = await _contractRepository.Get().ToArrayAsync();
            return Ok(contracts);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Contract contract)
        {
            var newContract = await _contractRepository.AddAsync(contract);
            await _contractRepository.SaveChangesAsync();
            return Ok(new Tuple<bool, Contract?>(true, newContract));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var contract = await _contractRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (contract is not null)
            {
                _contractRepository.Remove(contract);
                await _contractRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] Contract Contract)
        {
            var finedContract = await _contractRepository.Get().AnyAsync(x => x.Id == Contract.Id);
            if (finedContract)
            {
                _contractRepository.Update(Contract);
                await _contractRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, Contract?>(true, Contract));
            }
            return Ok(new Tuple<bool, Contract?>(false, Contract));
        }
    }
}

