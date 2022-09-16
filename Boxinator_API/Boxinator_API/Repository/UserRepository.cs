using Boxinator_API.Data;
using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxinator_API.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BoxApiDbContext _context;
        public UserRepository(BoxApiDbContext context)
        {
            _context = context;
        }
        /// <summary>
        /// Add a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<User> AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }
        /// <summary>
        /// Delete a user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _context.Users.Include(u=>u.Shipments).ThenInclude(s=>s.user).ToListAsync();
        }
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.Include(u => u.Shipments).ThenInclude(s => s.user).FirstOrDefaultAsync(g => g.UserId == id);
        }
        /// <summary>
        /// Get user by email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.Include(u => u.Shipments).ThenInclude(s => s.user).FirstOrDefaultAsync(g => g.Email == email);
        }
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Adds shipment to User
        /// </summary>
        /// <returns></returns>
        public async Task AddShipmentToUser(User user, Shipment shipment)
        {
            user.Shipments.Add(shipment);
            await UpdateUser(user);
        }

        /// <summary>
        /// Saves changes of dbContext
        /// </summary>
        public void Save()
        {
            _context.SaveChanges();
        }

        /// <summary>
        /// Returns true if user exist in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UserExist(int id)
        {
            return _context.Users.Any(s => s.UserId == id);
        }
    }
}
