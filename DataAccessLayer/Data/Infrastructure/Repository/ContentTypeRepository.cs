using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ContentTypeRepository : IRepository<ContentType>, IContentTypeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ContentTypeRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }
        public void update(ContentType contentType)
        {
            _dbContext.ContentTypes.Update(contentType);
        }
    }
}
