using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxinator_API.Repository
{
    public class GuestUserRepository : IGuestUserRepository
    {
        public Task<GuestUser> CreateUser(GuestUser guestUser)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GuestUser>> GetAllGuestUsers(GuestUser guestUser)
        {
            throw new System.NotImplementedException();
        }

        public Task<GuestUser> GetGuestUserById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateGuestUser(GuestUser guestUser)
        {
            throw new System.NotImplementedException();
        }
    }
}
