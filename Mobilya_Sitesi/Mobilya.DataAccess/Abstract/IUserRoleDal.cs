using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface IUserRoleDal:IGenericDal<UserRole>
    {
        void AddUserToRole(int userId,int roleId);
        void AddUserToRole(int userId,string roleName);
        void RemoveUserFromRole(int userId, int roleId);
        void RemoveUserFromRole(int userId, string roleName);
        void RemoveAllRolesByUserId(int userId);
    }
}
