using Boxinator_API.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxinator_API.Interfaces
{
    public interface IUserRepository
    {
        // Basic CRUD
        public Task<User> GetUserById(int id);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<User> AddUser (User user);
        public Task UpdateUser (User user);
        public Task DeleteUser(int id);
    }
}
