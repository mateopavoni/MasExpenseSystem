using MasExpenseSystem.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace MasExpenseSystem.DTOs
{
    public class TransactionDTO
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public DateOnly Date { get; set; }
        public string Comment { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }
    }
}
