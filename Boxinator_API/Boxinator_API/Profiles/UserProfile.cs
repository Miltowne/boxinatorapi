using AutoMapper;
using Boxinator_API.Model.Const.DTO.Shipment;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.User;
using System.Linq;

namespace Boxinator_API.Profiles
{
    public class UserProfile : Profile
    {
        /// <summary>
        /// User -> UserDTO's mapping
        /// </summary>
        public UserProfile()
        {
            // User -> UserCreateDTO Mapping
            CreateMap<User, UserCreateDTO>()
                .ReverseMap();

            // User -> UserGetDTO Mapping
            CreateMap<User, UserGetDTO>()
                .ForMember(uDTO => uDTO.Shipments, opt => opt
                .MapFrom(u => u.Shipments
                .Select(shipment => shipment.ShipmentId)
                .ToList()));

            // User -> UserUpdateDTO Mapping
            CreateMap<User, UserUpdateDTO>()
                .ReverseMap();
        }
    }
}
