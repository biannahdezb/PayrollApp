using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payroll.Models;
using payroll.Data;

namespace Payroll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeductionTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public DeductionTypesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeductionTypes>>> GetDeductionTypes()
        {
            return await _context.DeductionTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DeductionTypes>> GetDeductionType(int id)
        {
            var deductionType = await _context.DeductionTypes.FindAsync(id);
            if (deductionType == null)
            {
                return NotFound();
            }
            return deductionType;
        }

        [HttpPost]
        public async Task<ActionResult<DeductionTypes>> PostDeductionType(DeductionTypes deductionType)
        {
            _context.DeductionTypes.Add(deductionType);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDeductionType), new { id = deductionType.Id }, deductionType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeductionType(int id, DeductionTypes deductionType)
        {
            if (id != deductionType.Id)
            {
                return BadRequest();
            }

            _context.Entry(deductionType).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DeductionTypes.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteDeductionType(int id)
        {
            var deductionType = await _context.DeductionTypes.FindAsync(id);
            if (deductionType == null)
            {
                return NotFound();
            }

            _context.DeductionTypes.Remove(deductionType);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
