using AutoMapper;
using Boxinator_API.Interfaces;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.GuestUser;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Boxinator_API.Controllers
{
    //[EnableCors("Policy1")]
    [Route("api/v1/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]

    public class GuestUserController : ControllerBase
    {
        private readonly IGuestUserRepository _repository;
        private readonly IMapper _mapper;

        public GuestUserController(IGuestUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get GuestUser by Id from the table
        /// </summary>
        /// <param name="id">The Id of the GuestUser</param>
        /// <returns>The GuestUser</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestUserGetDTO>> GetGuestUserById(int id)
        {

            var specificGuestUser = await _repository.GetGuestUserById(id);
            var specificGuestUserDto = _mapper.Map<GuestUserGetDTO>(specificGuestUser);
            return specificGuestUserDto;
        }

        /// <summary>
        /// Gets all the GuestUsers from the table
        /// </summary>
        /// <returns>All GuestUsers in an IEnumerable list</returns>
        [HttpGet]
        public async Task<IEnumerable<GuestUserGetDTO>> GetAllGuestUsers()
        {
            var allGuestUsers = await _repository.GetAllGuestUsers();
            var allGuestUsersDto = _mapper.Map<List<GuestUserGetDTO>>(allGuestUsers);
            return allGuestUsersDto;
        }

        /// <summary>
        /// Adds a GuestUser to the table with the provided values
        /// </summary>
        /// <param name="guestUserDTO">The GuestUser that will be added</param>
        /// <returns>The added GuestUser</returns>
        [HttpPost("CreateGuestUser")]
        [ActionName(nameof(CreateGuestUser))]
        public async Task<ActionResult<GuestUserCreateDTO>> CreateGuestUser(GuestUserCreateDTO guestUserDTO)
        {
            var newGuestUser = _mapper.Map<GuestUser>(guestUserDTO);
            newGuestUser = await _repository.CreateGuestUser(newGuestUser);
            return CreatedAtAction(nameof(CreateGuestUser), new { id = newGuestUser.GuestUserId }, guestUserDTO);
        }

        /// <summary>
        /// Updates a GuestUser by ID
        /// </summary>
        /// <param name="id">The Id of the GuestUser</param>
        /// <param name="guestUserDTO">The new values of the GuestUser</param>
        /// <returns>A string</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestUser(int id, GuestUserUpdateDTO guestUserDTO)
        {
            if (id != guestUserDTO.guestUserId)
            {
                return BadRequest();
            }

            var guestUser = _mapper.Map<GuestUser>(guestUserDTO);
            await _repository.UpdateGuestUser(guestUser);

            return Ok("GuestUser has been uptaded!");
        }

        /// <summary>
        /// Deletes a GuestUser from the table by providing a Id
        /// </summary>
        /// <param name="id">The Id of the GuestUser</param>
        /// <returns>A string</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestUser(int id)
        {
            await _repository.DeleteGuestUser(id);
            return Ok("Selected GuestUser has been deleted");
        }
    }
}
