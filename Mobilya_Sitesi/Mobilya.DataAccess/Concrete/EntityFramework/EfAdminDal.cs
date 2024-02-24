using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>,IAdminDal
    {
        private readonly Context _context;
        public EfAdminDal(Context context) : base(context)
        {
            _context = context;
        }
        
        //public Admin GetAdminByLogin(Admin login)
        //{
        //   return  _context.Admins.FirstOrDefault(x=>x.UserName== login.UserName && x.Password==login.Password);
        //}
    }
}
