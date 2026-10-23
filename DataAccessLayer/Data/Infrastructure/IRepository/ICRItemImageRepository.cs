using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.IRepository
{
    public interface ICRItemImageRepository : IRepository<CRItemImage>
    {
        void update(CRItemImage crItemImage); 
    }
}
