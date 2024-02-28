using Mobilya.Business.DTOs.UserRoleDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IUserRoleService
    {
        void AddUserRole(CreateUserRoleDTO createUserRoleDTO);
        

    }
}
