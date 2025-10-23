using System.ComponentModel.DataAnnotations.Schema;

namespace MasExpenseSystem.Entities
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        public DateOnly Date { get; set; }
        public string Comment { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Total {  get; set; }
        public User User { get; set; }
        public Service Service { get; set; }
    }
}
