using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.RoleDTOs;
using Mobilya.Business.DTOs.UserDTOs;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }
        [HttpPost]
        public IActionResult AddRole(CreateRoleDTO createRoleDTO)
        {
            _roleService.AddRole(createRoleDTO);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {

            _roleService.DeleteRole(id);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateRole(UpdateRoleDTO updateRoleDTO)
        {
            _roleService.UpdateRole(updateRoleDTO);
            return Ok();
        }
        [HttpGet]
        public IActionResult GetRolesList() {
            var values=_roleService.GetAllRoles();
            return Ok(values);
        }
        [HttpGet("GetRolesWithUsers")]
        public IActionResult GetRolesListWithUsers()
        {
            var values=_roleService.GetAllRolesWithUsers();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var value=_roleService.GetRoleById(id);
            return Ok(value);
        }
        [HttpGet("GetRoleWithUsers/{id}")]
        public IActionResult GetRoleWithUsers(int id)
        {
            var value=_roleService.GetRoleByIdWithUsers(id);
            return Ok(value);
        }
        [HttpGet("GetRoleByNameWithUsers/{id}")]
        public IActionResult GetRoleByName(string id)
        {
            var value=_roleService.GetRoleByNameWithUsers(id);
            return Ok(value);
        }


    }
}
