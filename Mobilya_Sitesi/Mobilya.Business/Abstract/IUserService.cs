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
        ResultUserDTO GetUserWtihRoles(int id);
        List<ResultUserDTO> GetUserList();
        List<ResultUserDTO> GetUserListWithRoles();
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
