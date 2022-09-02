using System.Collections.Generic;
using System;

namespace Boxinator_API.Model.Const.DTO.User
{
    public class UserGetDTO
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Country { get; set; }
        public int PostalCode { get; set; }
        public int PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public AccountType AccountType { get; set; }
        public List<int> Shipments { get; set; }
    }
}
