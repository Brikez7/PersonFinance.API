using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.BLL.Mappers;
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
            var contracts = await _contractRepository.Get().Select(x => x.ToContractDTO()).ToArrayAsync();
            return Ok(contracts);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RequestNewContract contract)
        {
            var newContract = await _contractRepository.AddAsync(contract.ToContract());
            await _contractRepository.SaveChangesAsync();
            return Ok(new Tuple<bool, ContractDTO>(true, newContract.ToContractDTO()));
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
        public async Task<IActionResult> Put([FromBody] ContractDTO Contract)
        {
            var finedContract = await _contractRepository.Get().AnyAsync(x => x.Id == Contract.Id);
            if (finedContract)
            {
                _contractRepository.Update(Contract.ToContract());
                await _contractRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, ContractDTO>(true, Contract));
            }
            return Ok(new Tuple<bool, ContractDTO>(false, Contract));
        }
    }
}

