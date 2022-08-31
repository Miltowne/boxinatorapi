using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boxinator_API.Repository
{
    public class ShipmentRepository : IShipmentRepository
    {
        public Task<Shipment> AddShipment(Shipment shipment)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteShipment(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Shipment>> GetAllShipments(Shipment shipment)
        {
            throw new System.NotImplementedException();
        }

        public Task<Shipment> GetShipmentById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateShipment(Shipment shipment)
        {
            throw new System.NotImplementedException();
        }
    }
}
