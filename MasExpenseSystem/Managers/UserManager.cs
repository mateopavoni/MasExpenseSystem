using MasExpenseSystem.Context;
using MasExpenseSystem.Models;

namespace MasExpenseSystem.Managers
{
    public class UserManager(AppDbContext _dbContext)
    {
        public UserVM Login(LoginVM vm)
        {
            var found = _dbContext.Users.Where(item =>
                    item.Email == vm.Email &&
                    item.Password == vm.Password
                ).FirstOrDefault();

            var user= new UserVM();

            if (user != null)
            {
                user.UserId = found.UserId;
                user.FullName = found.FullName;
                user.Email = found.Email;
            }

            return user;
        }
    }
}
