using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using payroll.Models;
using payroll.Data;

namespace Payroll.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingEntriesController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountingEntriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AccountingEntries>>> GetAccountingEntries()
        {
            return await _context.AccountingEntries.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AccountingEntries>> GetAccountingEntry(int id)
        {
            var accountingEntry = await _context.AccountingEntries.FindAsync(id);
            if (accountingEntry == null)
            {
                return NotFound();
            }
            return accountingEntry;
        }

        [HttpPost]
        public async Task<ActionResult<AccountingEntries>> PostAccountingEntry(AccountingEntries accountingEntry)
        {
            _context.AccountingEntries.Add(accountingEntry);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetAccountingEntry), new { id = accountingEntry.EntryId }, accountingEntry);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccountingEntry(int id, AccountingEntries accountingEntry)
        {
            if (id != accountingEntry.EntryId)
            {
                return BadRequest();
            }

            _context.Entry(accountingEntry).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.AccountingEntries.Any(e => e.EntryId == id))
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
        public async Task<IActionResult> DeleteAccountingEntry(int id)
        {
            var accountingEntry = await _context.AccountingEntries.FindAsync(id);
            if (accountingEntry == null)
            {
                return NotFound();
            }

            _context.AccountingEntries.Remove(accountingEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
