using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class DocumentTypeRepository : IRepository<DocumentType>, IDocumentTypeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public DocumentTypeRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(DocumentType documentType)
        {
            _dbContext.DocumentTypes.Update(documentType);
        }
    }
}
