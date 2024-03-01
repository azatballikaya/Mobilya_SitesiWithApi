using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete.EntityFramework
{
    public class EfCartDal : GenericRepository<Cart>, ICartDal
    {
        private readonly Context _context;
        public EfCartDal(Context context) : base(context)
        {
        }
    }
}
