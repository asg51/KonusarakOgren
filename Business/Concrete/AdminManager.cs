using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminDal adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal; 
        }
        public Admin Get(Expression<Func<Admin, bool>> filter)
        {
            return this.adminDal.Get(filter);
        }
    }
}
