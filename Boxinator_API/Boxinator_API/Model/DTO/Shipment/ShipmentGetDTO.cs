namespace Boxinator_API.Model.Const.DTO.Shipment
{
    public class ShipmentGetDTO
    {
        public int ShipmentId { get; set; }
        public string RecieverName { get; set; }
        public int Weight { get; set; }
        public string Destination { get; set; }
        public string BoxColor { get; set; }
        public ShipmentStatus ShipmentStatus { get; set; }
    }
}
