using Microsoft.AspNetCore.Mvc;
using PersonFinance.API.DAL;

namespace PersonFinance.API.Controllers
{
    [Route("PersonFinance/v1/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<ContractController> _logger;
        private PersonFinanceContext _context;
        public TestController(ILogger<ContractController> logger, PersonFinanceContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("RefreshDatabase")]
        public async Task<IActionResult> RefreshDatabase() 
        {
            await _context.Database.EnsureDeletedAsync();
            await _context.Database.EnsureCreatedAsync();
            return Ok();
        }
    }
}
