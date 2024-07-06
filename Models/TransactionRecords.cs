using System.ComponentModel.DataAnnotations;

namespace payroll.Models
{
    public class TransactionRecords
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public int IncomeOrDeductionId { get; set; }
        public string TransactionType { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public bool State { get; set; }
    }
}