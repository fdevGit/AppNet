using AppNet.Domain.Models;
using AppNet.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Repository.Infrastructure
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User Login(string userName, string password);
        bool ChangePassword(User entity, string newPassword);
        bool Register(User entity);
        bool LostPassword(string userName);
        bool Lock(int userId);
        bool Lock(string userName);
        bool UnLock(int userId);
        bool UnLock(string userName);
    }
}
