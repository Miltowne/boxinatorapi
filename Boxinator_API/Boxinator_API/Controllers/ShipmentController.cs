using AutoMapper;
using Boxinator_API.Data;
using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.Shipment;
using Boxinator_API.Model.DTO.Shipment;
using Boxinator_API.Repository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Boxinator_API.Controllers
{
    //[EnableCors("Policy1")]
    [Route("api/v1/shipments")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class ShipmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ShipmentRepository _repo;
        private readonly UserRepository _userRepo;
        private readonly IGuestUserRepository _guestUserRepo;

        public ShipmentController(IMapper mapper, BoxApiDbContext context, IGuestUserRepository guestUserRepository)
        {
            _guestUserRepo = guestUserRepository;
            _userRepo = new UserRepository(context);
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
        /// Get shipments from user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<ShipmentGetDTO>>> GetUserShipments(int id)
        {
            if (!_userRepo.UserExist(id))
            {
                return NotFound();
            }
            User user = await _userRepo.GetUserById(id);
            List<ShipmentGetDTO> shipmentList = new();
            foreach (var shipment in user.Shipments)
            {
                shipmentList.Add(_mapper.Map<ShipmentGetDTO>(shipment));
            }
            return Ok(shipmentList);
        }

        /// <summary>
        /// Get shipments from guestUser
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("guestuser/{id}")]
        public async Task<ActionResult<IEnumerable<ShipmentGetDTO>>> GetGuestUserShipments(int id)
        {
            if (!_userRepo.UserExist(id))
            {
                return NotFound();
            }
            GuestUser guestUser = await _guestUserRepo.GetGuestUserById(id);
            List<ShipmentGetDTO> shipmentList = new();
            foreach (var shipment in guestUser.Shipments)
            {
                shipmentList.Add(_mapper.Map<ShipmentGetDTO>(shipment));
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
        /// Add a new Shipment and apply guestuser id
        /// </summary>
        /// <param name="shipmentDTO"></param>
        /// <returns></returns>
        [HttpPost("guestuser")]
        public async Task<ActionResult<Shipment>> AddShipmentToGuestUser(ShipmentGuestUserCreateDTO shipmentDTO)
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
