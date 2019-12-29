using AppNet.Domain.Models;
using AppNet.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppNet.Repository.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository() : base()
        {

        }

        public bool ChangePassword(User entity, string newPassword)
        {
            return false;
        }

        public bool Lock(int userId)
        {
            throw new NotImplementedException();
        }

        public bool Lock(string userName)
        {
            throw new NotImplementedException();
        }

        public User Login(string userName, string password)
        {
            return GetAll(t => t.EmailAddress == userName && t.Password == password).FirstOrDefault();
            //return entityObject.FirstOrDefault();
        }

        public bool LostPassword(string userName)
        {
            throw new NotImplementedException();
        }

        public bool Register(User entity)
        {
            throw new NotImplementedException();
        }

        public bool UnLock(int userId)
        {
            throw new NotImplementedException();
        }

        public bool UnLock(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
