using System.Threading.Tasks;
using HealthInsurance.Core.Data;
using HealthInsurance.Core.Interfaces.Specifications;

namespace HealthInsurance.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private HealthInsuranceContext _context;
        public IRepository Repository { get; }

        public UnitOfWork(HealthInsuranceContext healthInsuranceContext, IRepository repository)
        {
            _context = healthInsuranceContext;
            Repository = repository;
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
