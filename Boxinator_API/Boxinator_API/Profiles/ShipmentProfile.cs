using AutoMapper;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.Shipment;

namespace Boxinator_API.Profiles
{
    public class ShipmentProfile: Profile
    {
        /// <summary>
        /// Shipment -> ShipmentDTO's mapping
        /// </summary>
        public ShipmentProfile()
        {
            // Shipment -> ShipmentGetDTO Mapping
            CreateMap<Shipment, ShipmentGetDTO>()
                .ReverseMap();

            // Shipment -> ShipmentCreateDTO Mapping
            CreateMap<Shipment, ShipmentCreateDTO>()
                .ReverseMap();

            // Shipment -> ShipmentUpdateDTO Mapping
            CreateMap<Shipment, ShipmentUpdateDTO>()
                .ReverseMap();


        }
    }
}
