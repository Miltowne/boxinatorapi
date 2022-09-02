using Boxinator_API.Data;
using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxinator_API.Repository
{
    public class GuestUserRepository : IGuestUserRepository
    {
        private readonly BoxApiDbContext _context;
        public GuestUserRepository(BoxApiDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a GuestUser to the table
        /// </summary>
        /// <param name="guestUser">The GuestUser to be added</param>
        /// <returns>The GuestUser that was added</returns>
        public async Task<GuestUser> CreateGuestUser(GuestUser guestUser)
        {
            _context.GuestUsers.Add(guestUser);
            await _context.SaveChangesAsync();
            return guestUser;
        }

        /// <summary>
        /// Deletes a GuestUser from the table 
        /// </summary>
        /// <param name="id">The Id of the GuestUser that will be deleted</param>
        /// <returns></returns>
        public async Task DeleteGuestUser(int id)
        {
            var guestUser = await _context.GuestUsers.FindAsync(id);

            _context.GuestUsers.Remove(guestUser);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all GuestUsers from the table
        /// </summary>
        /// <returns>A IEnumerable list with all GuestUsers</returns>
        public async Task<IEnumerable<GuestUser>> GetAllGuestUsers()
        {
            return await _context.GuestUsers.ToListAsync();
        }

        /// <summary>
        /// Gets a GuestUser by Id
        /// </summary>
        /// <param name="id">The Id of the GuestUser</param>
        /// <returns>The GuestUser</returns>
        public async Task<GuestUser> GetGuestUserById(int id)
        {
            return await _context.GuestUsers.FirstOrDefaultAsync(g => g.GuestUserId == id);
        }

        /// <summary>
        /// Updates a GuestUser in the table by provided Id
        /// </summary>
        /// <param name="guestUser">The GuestUser that will be updated</param>
        /// <returns></returns>
        public async Task UpdateGuestUser(GuestUser guestUser)
        {
           _context.Entry(guestUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
