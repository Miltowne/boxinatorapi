using Boxinator_API.Model.Const;

namespace Boxinator_API.Model.DTO.Shipment
{
    public class ShipmentGuestUserCreateDTO
    {
        public string RecieverName { get; set; }
        public int Weight { get; set; }
        public string Destination { get; set; }
        public string BoxColor { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
        //public int UserId { get; set; }

        public int GuestUserId { get; set; }
    }
}
