using Microsoft.EntityFrameworkCore;
using payroll.Models;

namespace payroll.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<IncomeTypes> IncomeTypes { get; set; }
        public DbSet<DeductionTypes> DeductionTypes { get; set; }
        public DbSet<TransactionRecords> TransactionRecords { get; set; }
        public DbSet<AccountingEntries> AccountingEntries { get; set; }

        // Add DbSet properties for other entities as needed

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your entity mappings, relationships, and constraints here
            // For example:
            modelBuilder.Entity<AccountingEntries>()
                .Property(a => a.EntryId)
                .ValueGeneratedOnAdd(); // Ensure EntryId is auto-generated on add
        }
    }
}
