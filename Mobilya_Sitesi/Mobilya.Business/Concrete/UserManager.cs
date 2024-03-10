using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.RoleDTOs;
using Mobilya.Business.DTOs.UserDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly IUserRoleDal _userRoleDal;
        private readonly ICartDal _cartDal;
        private readonly IMapper _mapper;
        public UserManager(IUserDal userDal, IMapper mapper, IUserRoleDal userRoleDal, ICartDal cartDal)
        {
            _userDal = userDal;
            _mapper = mapper;
            _userRoleDal = userRoleDal;
            _cartDal = cartDal;
        }

        public void AddUserToRole(int userId, int roleId)
        {
            _userRoleDal.AddUserToRole(userId, roleId);
        }

        public void AddUserToRole(int userId, string roleName)
        {
            _userRoleDal.AddUserToRole(userId,roleName);
        }
        public void RemoveUserFromRole(int userId, int roleId)
        {
           _userRoleDal.RemoveUserFromRole(userId,roleId);
        }

        public void RemoveUserFromRole(int userId, string roleName)
        {
            _userRoleDal.RemoveUserFromRole(userId,roleName);
        }

        public void CreateUser(CreateUserDTO createUserDTO)
        {
            
                

            User newUser= new User()
            {
                UserName = createUserDTO.UserName,
                Password = createUserDTO.Password,
                
            };
            newUser=_userDal.Insert(newUser);
            var userRoles = createUserDTO.RoleIds.Select(r => new UserRole
            {
                UserId = newUser.UserId,
                RoleId = r
            }).ToList();
            foreach (var userRole in userRoles)
            {
                _userRoleDal.Insert(userRole);
            }
            _cartDal.Insert(new Cart
            {
                UserId = newUser.UserId,
            });
           
        }

        public void DeleteUser(int id)
        {
            RemoveUserFromAllRoles(id);
            _userDal.Delete(_userDal.GetById(id));
        }

        public ResultUserDTO GetUser(int id)
        {
            var value=_userDal.GetById(id);
            var user = _mapper.Map<ResultUserDTO>(value);
            return user;
        }
		public ResultUserDTO GetUserByUserName(string userName)
		{
			var value = _userDal.Get(x=>x.UserName == userName);
			var user = _mapper.Map<ResultUserDTO>(value);
			return user;
		}

		public LoginUserDTO? GetUserByLogin(LoginUserDTO loginUserDTO)
        {
            User user=_userDal.Get(x=>x.UserName==loginUserDTO.UserName && x.Password==loginUserDTO.Password, x=>x.Include(y=>y.UserRoles).ThenInclude(z=>z.Role));
            if(user!=null)
            {
                loginUserDTO.UserId = user.UserId;
                loginUserDTO.UserName = user.UserName;
                loginUserDTO.Password = user.Password;
                loginUserDTO.RoleNames = user.UserRoles.Select(x => x.Role.RoleName).ToList();
				return loginUserDTO;
			}
            else
            {
                return null;

            }

        }

        public List<ResultUserDTO> GetUserList()
        {
            var value=_mapper.Map<List<ResultUserDTO>>(_userDal.GetAll());
            return value;
        }

     
        

        public ResultUserDTO GetUserWtihRoles(int id)
        {
            var user= _userDal.Get(x=>x.UserId==id, x=>x.Include(x=>x.UserRoles).ThenInclude(x=>x.Role));
            return new ResultUserDTO
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Password = user.Password,
                Roles = user.UserRoles.Select(x=>new ResultRoleDTO
                {
                    RoleId= x.Role.RoleId,
                    RoleName=x.Role.RoleName,
                }).ToList(),
            };
        }

   

        public void UpdateUser(UpdateUserDTO updateUserDTO)
        {
            User updateUser = new User
            {
                UserId = updateUserDTO.UserId,
                UserName = updateUserDTO.UserName,
                Password = updateUserDTO.Password,
               
            };
            _userDal.Update(updateUser);
            RemoveUserFromAllRoles(updateUser.UserId);
            foreach (var item in updateUserDTO.RoleIds)
            {
                AddUserToRole(updateUser.UserId, item);
            }
        }
        public void RemoveUserFromAllRoles(int userId)
        {
            _userRoleDal.RemoveAllRolesByUserId(userId);
        }

        public List<ResultUserDTO> GetUserListWithRoles()
        {
            var list= _userDal.GetAll(include: x => x.Include(y => y.UserRoles).ThenInclude(z => z.Role));
            var values=_mapper.Map<List<ResultUserDTO>>(list);
            return values;
            
        }
        public List<ResultUserDTO> GetUserListWithRoles(string roleName)
        {
            var list= _userDal.GetAll(filter:x=>x.UserRoles.Any(y=>y.Role.RoleName==roleName),include: x => x.Include(y => y.UserRoles).ThenInclude(z => z.Role));
            var values=_mapper.Map<List<ResultUserDTO>>(list);
            return values;
            
        }
        public List<ResultUserDTO> GetUsersByRoleId(int roleId)
        {
            var users = _userDal.GetAll(x => x.UserRoles.Any(y => y.RoleId == roleId),x=>x.Include(y=>y.UserRoles).ThenInclude(z=>z.Role));
            var dtos = _mapper.Map<List<ResultUserDTO>>(users);
            return dtos;
        }
    }
}
