using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantDocTypeRepository : IRepository<ApplicantDocType>, IApplicantDocTypeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantDocTypeRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(ApplicantDocType applicantDocType)
        {
            _dbContext.ApplicantDocTypes.Update(applicantDocType);
        }
    }
}
