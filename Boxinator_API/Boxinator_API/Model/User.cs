using System;
using System.Collections.Generic;
using Boxinator_API.Model.Const;

namespace Boxinator_API.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public ICollection<Shipment> Shipments { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AccountType AccountType { get; set; }

    }
}
