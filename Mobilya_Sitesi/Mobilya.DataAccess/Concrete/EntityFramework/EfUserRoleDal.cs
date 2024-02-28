using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal:GenericRepository<UserRole>,IUserRoleDal
    {
        private readonly Context _context;

        public EfUserRoleDal(Context context):base(context) 
        {
            _context = context;
        }

        public void AddUserToRole(int userId, int roleId)
        {
            var user = _context.Users.Find(userId);
            var role = _context.Roles.Find(roleId);
            var userRole=_context.UserRoles.FirstOrDefault(x=>x.UserId==userId && x.RoleId==roleId);
            if(user!=null && role!=null && userRole==null)
            {
                _context.UserRoles.Add(new UserRole { UserId=userId, RoleId=roleId });
                _context.SaveChanges();
            }
        }

        public void AddUserToRole(int userId, string roleName)
        {
            var user = _context.Users.Find(userId);
            var role = _context.Roles.FirstOrDefault(x=>x.RoleName==roleName);
            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == userId && x.RoleId == role.RoleId);
            if (user != null && role != null && userRole == null)
            {
                _context.UserRoles.Add(new UserRole { UserId = userId, RoleId = role.RoleId });
                _context.SaveChanges();
            }
        }

        public void RemoveAllRolesByUserId(int userId)
        {
             var userRoleList=   _context.UserRoles.Where(x => x.UserId == userId);
            _context.UserRoles.RemoveRange(userRoleList);
            _context.SaveChanges() ;
        }

        public void RemoveUserFromRole(int userId, string roleName)
        {
            var user=_context.Users.Find(userId);
            var role = _context.Roles.FirstOrDefault(x => x.RoleName == roleName);
            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == user.UserId && x.RoleId == role.RoleId);
            if(user!= null && role != null && userRole!= null)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();
            }
        }

        public void RemoveUserFromRole(int userId, int roleId)
        {
            var user=_context.Users.Find(userId);
            var role = _context.Roles.FirstOrDefault(y => y.RoleId == roleId);
            var userRole = _context.UserRoles.FirstOrDefault(x => x.UserId == user.UserId && x.RoleId == role.RoleId);
            if(user!= null && role != null && userRole!=null)
            {
                _context.UserRoles.Remove(userRole);
                _context.SaveChanges();

            }
        }
    }
}
