using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class MaintenanceRepository : IRepository<Maintenance>, IMaintenanceRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public MaintenanceRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(Maintenance maintenance)
        {
            _dbContext.Maintenance.Update(maintenance);
        }
    }
}
