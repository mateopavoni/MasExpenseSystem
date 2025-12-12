using System.ComponentModel.DataAnnotations.Schema;

namespace MasExpenseSystem.DTOs
{
    public class HistoryDTO
    {
        public string Service { get; set; }
        public string TypeService { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string TotalAmount { get; set; }
    }
}
