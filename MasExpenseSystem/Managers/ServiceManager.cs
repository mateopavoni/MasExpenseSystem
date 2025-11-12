using MasExpenseSystem.Context;
using MasExpenseSystem.Entities;
using MasExpenseSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace MasExpenseSystem.Managers
{
    public class ServiceManager(AppDbContext _dbContext)
    {
        public List<ServiceVM> GetAll(int userId)
        {
            var list = _dbContext.Services.Where(s => s.UserId == userId).Select(s => new ServiceVM
            {
                ServiceId = s.ServiceId,
                UserId = s.UserId,
                Name = s.Name,
                Type = s.Type,
            }).ToList();

            return list;
        }

        public int New(ServiceVM vm)
        {
            var model = new Service
            {
                UserId = vm.UserId,
                Name = vm.Name,
                Type = vm.Type,
            };

            _dbContext.Services.Add(model);
            var rowsAffected = _dbContext.SaveChanges();
            return rowsAffected;

        }
    }
}
