using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ExpenseDocumentRepository : IRepository<ExpenseDocument>, IExpenseDocumentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ExpenseDocumentRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }
        public void update(ExpenseDocument expenseDocument)
        {
            _dbContext.ExpenseDocuments.Update(expenseDocument);
        }
    }
}
