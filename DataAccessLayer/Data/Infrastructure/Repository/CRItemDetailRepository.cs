using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class CRItemDetailRepository : IRepository<CRItemDetail>, ICRItemDetailRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public CRItemDetailRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(CRItemDetail crItemDetail)
        {
            _dbContext.CRItemDetails.Update(crItemDetail);
        }
    }
}
