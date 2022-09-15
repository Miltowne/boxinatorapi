using AutoMapper;
using Boxinator_API.Data;
using Boxinator_API.Model;
using Boxinator_API.Model.Const.DTO.GuestUser;
using Boxinator_API.Model.Const.DTO.Shipment;
using Boxinator_API.Model.Const.DTO.User;
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
    [Route("api/v1/users")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class UserController: ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserController(BoxApiDbContext boxApiDbContext, IMapper mapper)
        {
            _userRepository = new UserRepository(boxApiDbContext);
            _mapper = mapper; 
        }
        /// <summary>
        /// Gets user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDTO>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserGetDTO>(user);
            return Ok(userDTO);
        }
        /// <summary>
        /// Gets user by email
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("email/{email}")]
        public async Task<ActionResult<UserGetDTO>> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                return NotFound();
            }
            var userDTO = _mapper.Map<UserGetDTO>(user);
            return Ok(userDTO);
        }
        /// <summary>
        /// Gets all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserGetDTO>> GetAllUser()
        {
            var allUsers = await _userRepository.GetAllUsers();
            var allUsersDto = _mapper.Map<List<UserGetDTO>>(allUsers);
            return allUsersDto;
        }
        /// <summary>
        /// Creates user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost()]
        //[ActionName(nameof(CreateUser))]
        public async Task<ActionResult<UserCreateDTO>> CreateUser(UserCreateDTO userDTO)
        {

            var newUser = _mapper.Map<User>(userDTO);
            newUser = await _userRepository.AddUser(newUser);
            return CreatedAtAction(nameof(GetUserById), new { id = newUser.UserId }, userDTO);

        }
        /// <summary>
        /// Updates user by id
        /// </summary>
        /// <param name="user"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(UserUpdateDTO userDTO, int id)
        {
            if (id != userDTO.UserId)
            {
                return BadRequest();
            }

            var user = _mapper.Map<User>(userDTO);
            await _userRepository.UpdateUser(user);

            return Ok("User has been uptaded!");
        }
        /// <summary>
        /// Delete user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteUser(id);
            return Ok("Selected User has been deleted");
        }
    }
}
