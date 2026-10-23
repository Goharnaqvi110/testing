using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class LeaseTenantRepository : IRepository<LeaseTenant>, ILeaseTenantRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public LeaseTenantRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(LeaseTenant leaseTenant)
        {
            _dbContext.LeaseTenants.Update(leaseTenant);
        }
    }
}
