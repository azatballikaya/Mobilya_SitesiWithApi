using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Mobilya.Business.Abstract;
using Mobilya.Business.DTOs.RoleDTOs;
using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.Business.Concrete
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        private readonly IUserRoleDal _userRoleDal;
        private readonly IMapper _mapper;
        public RoleManager(IRoleDal roleDal, IMapper mapper, IUserRoleDal userRoleDal)
        {
            _roleDal = roleDal;
            _mapper = mapper;
            _userRoleDal = userRoleDal;
        }

        public void AddRole(CreateRoleDTO createRoleDTO)
        {
            var role = _mapper.Map<Role>(createRoleDTO);
            _roleDal.Insert(role);
        }

        public void DeleteRole(int id)
        {
            var role=_roleDal.GetById(id);
            _roleDal.Delete(role);
            var userRoles=_userRoleDal.GetAll(x=>x.RoleId==id);
            foreach (var item in userRoles)
            {
                _userRoleDal.Delete(item);
            }
        }

        public List<ResultRoleDTO> GetAllRoles()
        {
            var values = _roleDal.GetAll();
            var roles=_mapper.Map<List<ResultRoleDTO>>(values);
            return roles;
        }

        public List<ResultRoleDTO> GetAllRolesWithUsers()
        {
            var values = _roleDal.GetAll(include:r=>r.Include(r=>r.UserRoles).ThenInclude(r=>r.User));
            var roles = _mapper.Map<List<ResultRoleDTO>>(values);
            return roles;
        }

        public ResultRoleDTO GetRoleById(int id)
        {
            var value=_roleDal.GetById(id);
            var role=_mapper.Map<ResultRoleDTO>(value);
            return role;
        }

        public ResultRoleDTO GetRoleByIdWithUsers(int id)
        {
            var value= _roleDal.Get(x=>x.RoleId==id, x=>x.Include(r=>r.UserRoles).ThenInclude(r=>r.User));
            var role=_mapper.Map<ResultRoleDTO>(value) ;
            return role;
        }

        public ResultRoleDTO GetRoleByName(string name)
        {
            var value = _roleDal.Get(r=>r.RoleName==name);
            var role = _mapper.Map<ResultRoleDTO>(value);
            return role;
        }

        public ResultRoleDTO GetRoleByNameWithUsers(string name)
        {
            var value = _roleDal.Get(r => r.RoleName == name,r=>r.Include(r=>r.UserRoles).ThenInclude(r=>r.User));
            var role = _mapper.Map<ResultRoleDTO>(value);
            return role;
        }

        public void UpdateRole(UpdateRoleDTO updateRoleDTO)
        {
            var role = _mapper.Map<Role>(updateRoleDTO);
            _roleDal.Update(role);
        }
    }
}
