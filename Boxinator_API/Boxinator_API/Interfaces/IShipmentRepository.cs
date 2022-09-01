using Boxinator_API.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxinator_API.Interfaces
{
    public interface IShipmentRepository
    {
        // Basic CRUD
        public Task<Shipment> GetShipmentById(int id);
        public Task<IEnumerable<Shipment>> GetAllShipments();
        public Task AddShipment(Shipment shipment);
        public void UpdateShipment(Shipment shipment);
        public Task DeleteShipment(int id);
    }
}
