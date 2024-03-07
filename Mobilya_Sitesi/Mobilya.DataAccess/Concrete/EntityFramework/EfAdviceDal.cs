using Mobilya.DataAccess.Abstract;
using Mobilya.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobilya.DataAccess.Concrete.EntityFramework
{
    public class EfAdviceDal : GenericRepository<Advice>, IAdviceDal
    {
        private readonly Context _context;
        public EfAdviceDal(Context context) : base(context)
        {
            _context = context;
        }
    }
}
