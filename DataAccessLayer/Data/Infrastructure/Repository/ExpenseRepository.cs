using Gharshare.DataAccessLayer.Data.Infrastructure.IRepository;
using Gharshare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gharshare.DataAccessLayer.Data.Infrastructure.Repository
{
    internal class ExpenseRepository : IRepository<Expense>, IExpenseRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ExpenseRepository(ApplicationDBContext context) : base(context)
        {
            _dbContext= context;
        }
        public void update(Expense expense)
        {
            _dbContext.Expenses.Update(expense);
        }
    }
}
