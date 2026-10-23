using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantDependentRepository : IRepository<ApplicantDependent>, IApplicantDependentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantDependentRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(ApplicantDependent applicantDependent)
        {
            _dbContext.ApplicantDependents.Update(applicantDependent);
        }
    }
}
