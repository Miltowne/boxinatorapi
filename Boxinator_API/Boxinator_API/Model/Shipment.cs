using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Boxinator_API.Model.Const;

namespace Boxinator_API.Model
{
    public class Shipment
    {
        public int ShipmentId { get; set; }
        [Required]
        public string RecieverName { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public string Destination { get; set; }
        public string BoxColor { get; set; }


        public int? UserId { get; set; }
        public int? GuestUserId { get; set; }
        [Required]
        public ShipmentStatus ShipmentStatus { get; set; }
    }
}
