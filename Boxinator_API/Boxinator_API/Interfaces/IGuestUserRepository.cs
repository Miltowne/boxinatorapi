using Boxinator_API.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxinator_API.Interfaces
{
    public interface IGuestUserRepository
    {
        // Basic CRUD
        public Task<GuestUser> GetGuestUserById (int id);
        public Task<IEnumerable<GuestUser>> GetAllGuestUsers(GuestUser guestUser);
        public Task<GuestUser> CreateUser(GuestUser guestUser);
        public Task UpdateGuestUser(GuestUser guestUser);
        public Task DeleteUser(int id);
    }
}
