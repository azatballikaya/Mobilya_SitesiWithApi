using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.AdminDTOs;

namespace Mobilya.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("Login")]
        public IActionResult LoginAdmin(LoginAdminDTO loginAdminDto)
        {
             var admin=  _adminService.GetAdminByLogin(loginAdminDto);
            if(admin == null)
            {
                return BadRequest();
            }
            return Ok(admin);
        }
        [HttpGet("{id}")]
        public IActionResult GetAdmin(int id)
        {
            var admin=_adminService.GetAdmin(id);
            return Ok(admin);
        }
        [HttpGet]
        public IActionResult GetAdminList()
        {
            var list= _adminService.GetAdminList();
            return Ok(list);
        }
        [HttpPost("AddAdmin")]
        public IActionResult AddAdmin(CreateAdminDTO createAdminDTO)
        {
            _adminService.CreateAdmin(createAdminDTO);
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateAdmin(UpdateAdminDTO updateAdminDTO)
        {
            _adminService.UpdateAdmin(updateAdminDTO);
            return Ok() ;
        }
        [HttpDelete]
        public IActionResult DeleteAdmin(int id)
        {
            _adminService.DeleteAdmin(id);
            return Ok();
        }
    }
}
