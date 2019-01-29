using System.Threading.Tasks;

namespace HealthInsurance.Core.Interfaces.Specifications
{
    public interface IUnitOfWork
    {
        IRepository Repository { get; }
        Task SaveChanges();
    }
}
