using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.UserDTOs;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        

        public UserController(IUserService userService)
        {
            _userService = userService;
            
        }

        [HttpPost("Login")]
        public IActionResult LoginUser(LoginUserDTO loginUserDTO)
        {
             var user=  _userService.GetUserByLogin(loginUserDTO);
            if(user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            
            var user=_userService.GetUser(id);
            return Ok(user);
        }
        [HttpGet("GetUserWithRoles/{id}")]
        public IActionResult GetUserWithRoles(int id)
        {

            var user = _userService.GetUserWtihRoles(id);
            return Ok(user);
        }

        [HttpGet("GetUsersWithRolesByName/{id}")]
        public IActionResult GetUsersByRole(string id)
        {

            var users = _userService.GetUserListWithRoles(id);
            return Ok(users);
        }
        [HttpGet]
        public IActionResult GetUserList()
        {
            var list = _userService.GetUserList();
            return Ok(list);
        }
        [HttpGet("GetAllUsersWithRoles")]
        public IActionResult GetAllUsersWithRoles()
        {

            var user = _userService.GetUserListWithRoles();
            return Ok(user);
        }
        [HttpPost("AddUser")]
        public IActionResult AddUser(CreateUserDTO createUserDTO)
        {
            _userService.CreateUser(createUserDTO);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDTO updateUserDTO)
        {
            _userService.UpdateUser(updateUserDTO);
            return Ok() ;
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
        [HttpPost("AddUserToRoleById")]
        public IActionResult AddUserToRole(int userId, int roleId)
        {
            _userService.AddUserToRole(userId, roleId);
            return Ok();
        }
        [HttpPost("AddUserToRoleByName")]
        public IActionResult AddUserToRole(int userId, string roleName)
        {
            _userService.AddUserToRole(userId, roleName);
            return Ok();
        }
        [HttpPost("RemoveUserFromRoleById")]
        public IActionResult RemoveUserFromRole(int userId, int roleId)
        {
            _userService.RemoveUserFromRole(userId, roleId);
            return Ok();
        }
        [HttpPost("RemoveUserFromRoleByName")]
        public IActionResult RemoveUserFromRole(int userId, string roleName)
        {
            _userService.RemoveUserFromRole(userId, roleName);
            return Ok();
        }

    }
}
