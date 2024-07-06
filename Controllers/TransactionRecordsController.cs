using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payroll.Models;
using payroll.Data;

namespace Payroll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionRecordsController : ControllerBase
    {
        private readonly DataContext _context;

        public TransactionRecordsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionRecords>>> GetTransactionRecords()
        {
            return await _context.TransactionRecords.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionRecords>> GetTransactionRecord(int id)
        {
            var transactionRecord = await _context.TransactionRecords.FindAsync(id);
            if (transactionRecord == null)
            {
                return NotFound();
            }
            return transactionRecord;
        }

        [HttpPost]
        public async Task<ActionResult<TransactionRecords>> PostTransactionRecord(TransactionRecords transactionRecord)
        {
            _context.TransactionRecords.Add(transactionRecord);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTransactionRecord), new { id = transactionRecord.Id }, transactionRecord);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionRecord(int id, TransactionRecords transactionRecord)
        {
            if (id != transactionRecord.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionRecord).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TransactionRecords.Any(e => e.Id == id))
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
        public async Task<IActionResult> DeleteTransactionRecord(int id)
        {
            var transactionRecord = await _context.TransactionRecords.FindAsync(id);
            if (transactionRecord == null)
            {
                return NotFound();
            }

            _context.TransactionRecords.Remove(transactionRecord);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
