using AutoMapper;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.GuestUser;
using System.Linq;

namespace Boxinator_API.Mapping
{
    public class GuestUserMapping : Profile
    {
        public GuestUserMapping()
        {
            // GuestUser > GuestUserDTO
            CreateMap<GuestUser, GuestUserGetDTO>()
                .ForMember(guDTO => guDTO.Shipments, opt => opt
                .MapFrom(gu => gu.Shipments
                .Select(shipment => shipment.ShipmentId)
                .ToList()));

            // GuestUser > GuestUserCreateDTO
            CreateMap<GuestUser, GuestUserCreateDTO>().ReverseMap();
            // GuestUser > GuestUserUpdateDTO
            CreateMap<GuestUser, GuestUserUpdateDTO>().ReverseMap();
        }
    }
}
