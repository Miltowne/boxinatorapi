using System.Collections.Generic;

namespace Boxinator_API.Model.Const.DTO.GuestUser
{
    public class GuestUserGetDTO
    {
        public string Email { get; set; }
        public List<int> Shipments { get; set; }

    }
}
