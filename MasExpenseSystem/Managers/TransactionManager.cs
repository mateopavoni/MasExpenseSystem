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
    }
}
