using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Abstract
{
    public interface IAdminDal:IGenericDal<Admin>
    {
        //Admin GetAdminByLogin(Admin login);
    }
}
