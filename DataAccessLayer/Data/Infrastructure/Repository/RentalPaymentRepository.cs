using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class RentalPaymentRepository : IRepository<RentalPayment>, IRentalPaymentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public RentalPaymentRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(RentalPayment rentalPayment)
        {
            _dbContext.RentalPayments.Update(rentalPayment);
        }
    }
}
