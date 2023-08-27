using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;
using PersonFinance.API.Domain.Response;
using PersonFinance.API.BLL.Mappers;

namespace PersonCash.API.Controllers
{
    [ApiController]
    [Route("PersonFinance/v1/[controller]")]
    public class CashController : ControllerBase
    {
        private readonly IGenericRepository<Cash> _cashRepository;
        private readonly ILogger<CashController> _logger;
        public CashController(IGenericRepository<Cash> cashRepository, ILogger<CashController> logger)
        {
            _cashRepository = cashRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var cashes = await _cashRepository.Get().Select(x => x.ToCashDTO()).ToArrayAsync();
            return Ok(new StandardResponse<CashDTO[]>(cashes));
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] RequestNewCash cash)
        {
            var newCash = await _cashRepository.AddAsync(cash.ToCash());
            await _cashRepository.SaveChangesAsync();
            return Ok(new StandardResponse<CashDTO>(newCash.ToCashDTO()));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedCash = await _cashRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (deletedCash is not null)
            {
                _cashRepository.Remove(deletedCash);
                await _cashRepository.SaveChangesAsync();
                return Ok(new StandardResponse<bool>(true));
            }

            return Ok(new StandardResponse<bool>(false, ServiceCode.ErrorDelete));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] CashDTO cash)
        {
            var finedCash = await _cashRepository.Get().AnyAsync(x => x.Id == cash.Id);
            if (finedCash)
            {
                var updatedCash = _cashRepository.Update(cash.ToCash());
                await _cashRepository.SaveChangesAsync();
                return Ok(new StandardResponse<CashDTO>(cash));
            }
            return Ok(new StandardResponse<CashDTO>(cash, ServiceCode.ErrorUpdate));
        }
    }
}