using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ToolkitRepository : IRepository<Toolkit>, IToolkitRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ToolkitRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(Toolkit toolkit)
        {
            _dbContext.Toolkit.Update(toolkit);
        }
    }
}
