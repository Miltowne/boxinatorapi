using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxinator_API.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<User> AddUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateUser(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
