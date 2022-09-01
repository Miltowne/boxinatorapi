using AutoMapper;
using Boxinator_API.Model.Const.DTO.Shipment;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.User;

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
                .ReverseMap();

            // User -> UserUpdateDTO Mapping
            CreateMap<User, UserUpdateDTO>()
                .ReverseMap();
        }
    }
}
