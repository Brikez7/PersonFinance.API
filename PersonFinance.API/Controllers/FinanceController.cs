﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonFinance.API.DAL.Repositories;
using PersonFinance.API.Domain.Entities;

namespace PersonFinance.API.Controllers
{
    [ApiController]
    [Route("PersonFinance/v1/[controller]")]
    public class FinanceController : ControllerBase
    {
        private readonly IGenericRepository<Finance> _financeRepository;
        private readonly ILogger<FinanceController> _logger;
        public FinanceController(IGenericRepository<Finance> moneyAccountRepository, ILogger<FinanceController> logger)
        {
            _financeRepository = moneyAccountRepository;
            _logger = logger;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var moneyAccounts = await _financeRepository.Get().ToArrayAsync();
            return Ok(moneyAccounts);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] Finance finance)
        {
            var newFinance = await _financeRepository.AddAsync(finance);
            await _financeRepository.SaveChangesAsync();
            return Ok(new Tuple<bool, Finance?>(true, newFinance));
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var finance = await _financeRepository.Get().FirstOrDefaultAsync(x => x.Id == id);
            if (finance is not null)
            {
                _financeRepository.Remove(finance);
                await _financeRepository.SaveChangesAsync();
                return Ok(true);
            }

            return Ok(false);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Put([FromBody] Finance finance)
        {
            var finedFinance = await _financeRepository.Get().AnyAsync(x => x.Id == finance.Id);
            if (finedFinance)
            {
                _financeRepository.Update(finance);
                await _financeRepository.SaveChangesAsync();
                return Ok(new Tuple<bool, Finance?>(true, finance));
            }
            return Ok(new Tuple<bool, Finance?>(false, finance));
        }
    }
}

