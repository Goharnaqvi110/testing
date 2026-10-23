using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class BillDocumentRepository : IRepository<BillDocument>, IBillDocumentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public BillDocumentRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(BillDocument billDocument)
        {
            _dbContext.BillDocuments.Update(billDocument);
        }
    }
}
