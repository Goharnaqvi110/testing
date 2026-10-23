using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantAddIncomeRepository : IRepository<ApplicantAddIncome>, IApplicantAddIncomeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantAddIncomeRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(ApplicantAddIncome applicantAddIncome)
        {
            _dbContext.ApplicantAddIncomes.Update(applicantAddIncome);
        }
    }
}
