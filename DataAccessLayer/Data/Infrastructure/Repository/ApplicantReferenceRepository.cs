using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantReferenceRepository : IRepository<ApplicantReference>, IApplicantReferenceRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantReferenceRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(ApplicantReference applicantReference)
        {
            _dbContext.ApplicantReferences.Update(applicantReference);
        }
    }
}
