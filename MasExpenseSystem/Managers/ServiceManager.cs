using MasExpenseSystem.Context;
using MasExpenseSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace MasExpenseSystem.Managers
{
    public class ServiceManager(AppDbContext _dbContext)
    {
        public List<Service> GetAll(int userId)
        {
            var list = _dbContext.Services.Where(s => s.UserId == userId).ToList();

            return list;
        }
    }
}
