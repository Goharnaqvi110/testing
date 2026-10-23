using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantRepository : IRepository<Applicant>, IApplicantRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(Applicant applicant)
        {
            _dbContext.Applicants.Update(applicant);
        }        
    }
}
