using AutoMapper;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.UserRoleDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        private readonly IUserRoleDal _userRoleDal;
        private readonly IMapper _mapper;

        public UserRoleManager(IUserRoleDal userRoleDal, IMapper mapper)
        {
            _userRoleDal = userRoleDal;
            _mapper = mapper;
        }

        public void AddUserRole(CreateUserRoleDTO createUserRoleDTO)
        {
            var role = _mapper.Map<UserRole>(createUserRoleDTO);
            _userRoleDal.Insert(role);
        }
    }
}
