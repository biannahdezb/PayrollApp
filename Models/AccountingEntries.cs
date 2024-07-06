using System.ComponentModel.DataAnnotations;

namespace payroll.Models
{
    public class AccountingEntries
    {
        [Key]
        public int EntryId { get; set; }
        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public string Account { get; set; }
        public string MovementType { get; set; } // DB or CR
        public DateTime EntryDate { get; set; }
        public decimal EntryAmount { get; set; }
        public bool State { get; set; }
    }
}
