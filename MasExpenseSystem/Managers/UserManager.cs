using MasExpenseSystem.Context;
using MasExpenseSystem.Entities;
using MasExpenseSystem.Models;
using MasExpenseSystem.Utilities;
using System;

namespace MasExpenseSystem.Managers
{
    public class UserManager(AppDbContext _dbContext)
    {
        public UserVM Login(LoginVM vm)
        {
            var found = _dbContext.Users.Where(item =>
                    item.Email == vm.Email &&
                    item.Password == Sha256Hasher.ComputeHash(vm.Password)
                ).FirstOrDefault();

            var user = new UserVM();

            if (found != null)
            {
                user.UserId = found.UserId;
                user.FullName = found.FullName;
                user.Email = found.Email;
            }

            return user;
        }

        public int Register(UserVM vm)
        {
            if(vm.Password != vm.RepeatPassword)
            {
                throw new InvalidOperationException("Passwords do not match.");
            }

            var foundEmail = _dbContext.Users.Where(item =>
                    item.Email == vm.Email
                ).FirstOrDefault();

            if (foundEmail != null)
            {
                throw new InvalidOperationException("Email is already registered.");
            }

            var entity = new User
            {
                FullName = vm.FullName,
                Email = vm.Email,
                Password = Sha256Hasher.ComputeHash(vm.Password)
            };

            _dbContext.Users.Add(entity);
            var affected_rows = _dbContext.SaveChanges();
            return affected_rows;
        }
    }
}
