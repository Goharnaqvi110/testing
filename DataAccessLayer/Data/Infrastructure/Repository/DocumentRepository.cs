using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class DocumentRepository : IRepository<Document>, IDocumentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public DocumentRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(Document document)
        {
            _dbContext.Documents.Update(document);
        }
    }
}
