using ExpensiveControlApp.Infra.Database;
using ExpensiveControlApp.Models.Expensives;
using Microsoft.EntityFrameworkCore;

namespace ExpensiveControlApp.Services
{
    public class ExpensiveService : IExpensiveService
    {
        private readonly ExpensiveControlContext _dbContext;

        public ExpensiveService(ExpensiveControlContext Context) 
        {
            _dbContext = Context;
        }

        public async Task Create(DTOs.CreateExpensiveDTO createExpensiveDTO)
        {
            await _dbContext.Expensives.AddAsync(new Expensive()
            {
                Description = createExpensiveDTO.Description,
                Date = createExpensiveDTO.Date,
                Value = createExpensiveDTO.Value
            });
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Expensive>> FindBy(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
                throw new Exception("Data Final deve ser maior que Data Inicial!");

            var itens = await  _dbContext.Expensives.Where(e => e.Date >= startDate && e.Date <= endDate).AsNoTracking().ToListAsync();

            return itens;
        }

    }
}
