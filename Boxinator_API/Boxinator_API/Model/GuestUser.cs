using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Boxinator_API.Model
{
    public class GuestUser
    {
        public int GuestUserId { get; set; }
        public int Email { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
    }
}