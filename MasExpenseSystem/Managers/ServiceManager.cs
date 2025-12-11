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
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;

        }

        public ServiceVM GetById(int id)
        {
            var entity = _dbContext.Services.Find(id);

            var model = new ServiceVM
            {
                ServiceId = id,
                Name = entity.Name,
                Type = entity.Type,
            };

            return model;
        }

        public int Edit(ServiceVM model)
        {
            var entity = _dbContext.Services.Find(model.ServiceId);
            entity.Name = model.Name;
            entity.Type = model.Type;

            _dbContext.Services.Update(entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;
        }
    }
}
