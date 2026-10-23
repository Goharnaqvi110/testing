using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantHistoryRepository : IRepository<ApplicantHistory>, IApplicantHistoryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantHistoryRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }
        public void update(ApplicantHistory applicantHistory)
        {
            _dbContext.ApplicantHistory.Update(applicantHistory);
        }
    }
}
