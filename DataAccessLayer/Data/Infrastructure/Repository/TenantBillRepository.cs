using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class TenantBillRepository : IRepository<TenantBill>, ITenantBillRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public TenantBillRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(TenantBill tenantBill)
        {
            _dbContext.TenantBills.Update(tenantBill);
        }
    }
}
