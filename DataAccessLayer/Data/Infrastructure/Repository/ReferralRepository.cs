using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ReferralRepository : IRepository<Referral>, IReferralRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ReferralRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }
        public void update(Referral referral)
        {
            _dbContext.Referrals.Update(referral);
        }
    }
}
