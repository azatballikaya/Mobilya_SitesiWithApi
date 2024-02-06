using Mobilya.Business.DTOs.AdminDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IAdminService
    {
        Admin GetAdmin(int id);
        List<Admin> GetAdminList();
        void CreateAdmin(CreateAdminDTO createAdminDTO);
        void DeleteAdmin(int id);
        void UpdateAdmin(UpdateAdminDTO updateAdminDTO);
        LoginAdminDTO? GetAdminByLogin(LoginAdminDTO loginAdminDto);
    }
}
