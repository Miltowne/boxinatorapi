using AutoMapper;
using Boxinator_API.Data;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.Shipment;
using Boxinator_API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Boxinator_API.Controllers
{
    [Route("api/v1/shipments")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ShipmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ShipmentRepository _repo;

        public ShipmentController(IMapper mapper, BoxApiDbContext context)
        {
            _mapper = mapper;
            _repo = new ShipmentRepository(context);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Shipment>> GetShipmentById(int id)
        {
            var shipment = await _repo.GetShipmentById(id);
            if(shipment == null)
            {
                return NotFound();
            }
            return Ok(shipment);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShipmentGetDTO>>> GetShipments()
        {
            var shipmentList = await _repo.GetAllShipments();
            List<ShipmentGetDTO> shipList = new();
            foreach (var shipmentItem in shipmentList)
            {
               shipList.Add(_mapper.Map<ShipmentGetDTO>(shipmentItem));
            }
            return Ok(shipmentList);
        }

        /// <summary>
        /// Update a Shipment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="shipment"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> PutShipments(int id, ShipmentUpdateDTO shipmentDto)
        {
            if (id != shipmentDto.ShipmentId)
            {
                return BadRequest();
            }

            Shipment domainCharacter = _mapper.Map<Shipment>(shipmentDto);

            _repo.UpdateShipment(domainCharacter);

            try
            {
                _repo.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_repo.ShipmentExist(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        /// <summary>
        /// Add a new Shipment
        /// </summary>
        /// <param name="shipmentDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Shipment>> AddShipment(ShipmentCreateDTO shipmentDTO)
        {
            Shipment domainShipment = _mapper.Map<Shipment>(shipmentDTO);
            await _repo.AddShipment(domainShipment);
            _repo.Save();
            return CreatedAtAction("GetShipmentById",
                new { id = domainShipment.ShipmentId },
                _mapper.Map<ShipmentGetDTO>(domainShipment));
        }


        /// <summary>
        /// Deletes a shipment by id
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<ActionResult> DeleteShipment(int id)
        {
            Shipment shipment = await _repo.GetShipmentById(id);
            if (shipment == null)
            {
                return NotFound();
            }
            await _repo.DeleteShipment(id);

            _repo.Save();

            return NoContent();
        }

    }
}
