using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payroll.Models;
using payroll.Data;

namespace Payroll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public IncomeTypesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeTypes>>> GetIncomeTypes()
        {
            return await _context.IncomeTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IncomeTypes>> GetIncomeType(int id)
        {
            var incomeType = await _context.IncomeTypes.FindAsync(id);
            if (incomeType == null)
            {
                return NotFound();
            }
            return incomeType;
        }

        [HttpPost]
        public async Task<ActionResult<IncomeTypes>> PostIncomeType(IncomeTypes incomeType)
        {
            _context.IncomeTypes.Add(incomeType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetIncomeType), new { id = incomeType.Id }, incomeType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncomeType(int id, IncomeTypes incomeType)
        {
            if (id != incomeType.Id)
            {
                return BadRequest();
            }

            _context.Entry(incomeType).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.IncomeTypes.Any(e => e.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncomeType(int id)
        {
            var incomeType = await _context.IncomeTypes.FindAsync(id);
            if (incomeType == null)
            {
                return NotFound();
            }

            _context.IncomeTypes.Remove(incomeType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
