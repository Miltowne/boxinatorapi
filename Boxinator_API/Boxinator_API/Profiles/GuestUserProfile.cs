using AutoMapper;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.GuestUser;

namespace Boxinator_API.Profiles
{
    public class GuestUserProfile : Profile
    {

        /// <summary>
        /// GuestUser -> GuestUserDTO's mapping
        /// </summary>
        public GuestUserProfile()
        {
            // GuestUser -> GuestUserUpdateDTO Mapping
            CreateMap<GuestUser, GuestUserUpdateDTO>()
                    .ReverseMap();

            // GuestUser -> GuestUserCreateDTO Mapping
            CreateMap<GuestUser, GuestUserCreateDTO>()
                    .ReverseMap();

            // GuestUser -> GuestUserGetDTO Mapping
            CreateMap<GuestUser, GuestUserGetDTO>()
                    .ReverseMap();
        }
    }
}
