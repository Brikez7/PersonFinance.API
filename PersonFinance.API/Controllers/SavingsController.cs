using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    [ApiController]
    [Route("PersonFinance/v1/[controller]")]
    public class SavingsController : ControllerBase
    {
        private readonly ILogger<SavingsController> _logger;
        private readonly IGenericRepository<Savings> _savingsRepository;
        public SavingsController(ILogger<SavingsController> logger, IGenericRepository<Savings> savingsRepository)
        {
            _logger = logger;
            _savingsRepository = savingsRepository;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get() 
            => Ok(await _savingsRepository.Get().ToListAsync());
    }
}