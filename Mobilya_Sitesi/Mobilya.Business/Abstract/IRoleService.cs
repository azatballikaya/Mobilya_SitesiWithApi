using Microsoft.EntityFrameworkCore.Query;
using Mobilya.Business.DTOs.RoleDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IRoleService
    {
        List<ResultRoleDTO> GetAllRoles();
        List<ResultRoleDTO> GetAllRolesWithUsers();
        ResultRoleDTO GetRoleById(int id);
        ResultRoleDTO GetRoleByIdWithUsers(int id);
        ResultRoleDTO GetRoleByName(string name);
        ResultRoleDTO GetRoleByNameWithUsers(string name);
        void AddRole(CreateRoleDTO role);
        void DeleteRole(int id);
        void UpdateRole(UpdateRoleDTO role);
    }
}
