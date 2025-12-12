using MasExpenseSystem.Context;
using MasExpenseSystem.DTOs;
using MasExpenseSystem.Entities;

namespace MasExpenseSystem.Managers
{
    public class TransactionManager
    {
        private readonly AppDbContext _dbContext;

        public TransactionManager(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int New(TransactionDTO modelDto)
        {
            var entity = new Transaction
            {
                Date = modelDto.Date,
                Total = modelDto.Total,
                Comment = modelDto.Comment,
                ServiceId = modelDto.ServiceId,
                UserId = modelDto.UserId
            };

            _dbContext.Transactions.Add(entity);
            return _dbContext.SaveChanges();
        }

        public List<HistoryDTO> GetHistory(DateOnly startDate, DateOnly endDate, int userId)
        {
            var list = _dbContext.Transactions
                .Where(item =>
                    item.UserId == userId &&
                    item.Date >= startDate && item.Date <= endDate
                ).Select(item => new HistoryDTO
                {
                    Date = item.Date.ToString("dd/MM/yyyy"),
                    Month = char.ToUpper(item.Date.ToString("MMMM")[0]) + item.Date.ToString("MMMM").Substring(1).ToLower(),
                    Service = item.Service.Name,
                    TypeService = item.Service.Type,
                    TotalAmount = item.Total.ToString("F2")
                }).ToList();

            return list;
            
        }
    }
}
