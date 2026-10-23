using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ApplicantPetRepository : IRepository<ApplicantPet>, IApplicantPetRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ApplicantPetRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }
        public void update(ApplicantPet applicantPet)
        {
            _dbContext.ApplicantPets.Update(applicantPet);
        }
    }
}
