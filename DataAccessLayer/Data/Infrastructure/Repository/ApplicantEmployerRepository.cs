using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantEmployerRepository : IRepository<ApplicantEmployer>, IApplicantEmployerRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantEmployerRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(ApplicantEmployer applicantEmployer)
        {
            _dbContext.ApplicantEmployers.Update(applicantEmployer);
        }
    }
}
