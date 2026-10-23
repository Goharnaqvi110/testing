using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantVehicleRepository : IRepository<ApplicantVehicle>, IApplicantVehicleRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantVehicleRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(ApplicantVehicle applicantVehicle)
        {
            _dbContext.ApplicantVehicles.Update(applicantVehicle);
        }
    }
}
