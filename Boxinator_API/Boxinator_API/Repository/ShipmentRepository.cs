using Boxinator_API.Data;
using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boxinator_API.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly BoxApiDbContext _dbContext;

        public ShipmentRepository(BoxApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        /// <summary>
        /// Add a shipment
        /// </summary>
        /// <param name="shipment"></param>
        /// <returns></returns>
        public async Task AddShipment(Shipment shipment)
        {
            await _dbContext.Shipments.AddAsync(shipment);
        }
        /// <summary>
        /// Delete a shipment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteShipment(int id)
        {
            Shipment shipment = await _dbContext.Shipments.FindAsync(id);
            _dbContext.Shipments.Remove(shipment);
        }
        /// <summary>
        /// Get all shipments
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Shipment>> GetAllShipments()
        {
            return await _dbContext.Shipments.ToListAsync();
        }
        /// <summary>
        /// Get a shipment by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Shipment> GetShipmentById(int id)
        {
            return await _dbContext.Shipments.FirstOrDefaultAsync(s=>s.ShipmentId == id);
        }
        /// <summary>
        /// Update a shipment
        /// </summary>
        /// <param name="shipment"></param>
        public void UpdateShipment(Shipment shipment)
        {
            _dbContext.Entry(shipment).State = EntityState.Modified;
        }

        /// <summary>
        /// Saves changes of dbContext
        /// </summary>
        public void Save()
        {
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Returns true if shipment exist in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ShipmentExist(int id)
        {
            return _dbContext.Shipments.Any(s => s.ShipmentId == id);

        }
    }
}
