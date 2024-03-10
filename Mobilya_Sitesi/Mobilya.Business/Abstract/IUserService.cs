using Mobilya.Business.DTOs.UserDTOs;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Abstract
{
    public interface IUserService
    {
        ResultUserDTO GetUser(int id);
        ResultUserDTO GetUserByUserName(string userName);
        ResultUserDTO GetUserWtihRoles(int id);
        List<ResultUserDTO> GetUserList();
        List<ResultUserDTO> GetUserListWithRoles();
        List<ResultUserDTO> GetUserListWithRoles(string roleName);
        List<ResultUserDTO> GetUsersByRoleId(int roleId);
        void CreateUser(CreateUserDTO createUserDTO);
        void DeleteUser(int id);
        void UpdateUser(UpdateUserDTO updateUserDTO);
        LoginUserDTO? GetUserByLogin(LoginUserDTO loginUserDTO);
        void AddUserToRole(int userId, int roleId);
        void AddUserToRole(int userId, string roleName);
        void RemoveUserFromRole(int userId, int roleId);
        void RemoveUserFromRole(int userId, string roleName);

        //List<User> GetUsersByRole(string roleName);
    }
}
