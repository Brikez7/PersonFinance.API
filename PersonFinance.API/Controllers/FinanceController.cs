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
    public class FinanceController : ControllerBase
    {
        private readonly IGenericRepository<Finance> _financeRepository;
        private readonly ILogger<FinanceController> _logger;
        public FinanceController(IGenericRepository<Finance> financeRepository, ILogger<FinanceController> logger)
        {
            _financeRepository = financeRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var finances = await _financeRepository.Get().Select(x => x.ToFinanceDTO()).ToArrayAsync();
            return Ok(new StandardResponse<FinanceDTO[]>(finances));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RequestNewFinance finance)
        {
            var newFinance = await _financeRepository.AddAsync(finance.ToFinance());
            await _financeRepository.SaveChangesAsync();
            return Ok(new StandardResponse<FinanceDTO>(newFinance.ToFinanceDTO()));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedFinance = await _financeRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedFinance is not null)
            {
                _financeRepository.Remove(deletedFinance);
                await _financeRepository.SaveChangesAsync();
                return Ok(new StandardResponse<bool>(true));
            }

            return Ok(new StandardResponse<bool>(false, ServiceCode.ErrorDelete));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] FinanceDTO finance)
        {
            var finedFinance = await _financeRepository.Get().AnyAsync(x => x.Id == finance.Id);
            if (finedFinance)
            {
                var updatedFinance = _financeRepository.Update(finance.ToFinance());
                await _financeRepository.SaveChangesAsync();
                return Ok(new StandardResponse<FinanceDTO>(finance));
            }
            return Ok(new StandardResponse<FinanceDTO>(finance, ServiceCode.ErrorUpdate));
        }
    }
}