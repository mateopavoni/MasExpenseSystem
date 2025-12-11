using System.ComponentModel.DataAnnotations;

namespace MasExpenseSystem.Models
{
    public class ServiceVM
    {
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }
    }
}
