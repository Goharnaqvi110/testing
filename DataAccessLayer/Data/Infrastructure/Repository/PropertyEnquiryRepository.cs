using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class PropertyEnquiryRepository : IRepository<PropertyEnquiry>, IPropertyEnquiryRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public PropertyEnquiryRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }

        public void update(PropertyEnquiry propertyEnquiry)
        {
            _dbContext.PropertyEnquiries.Update(propertyEnquiry);
        }
    }
}
