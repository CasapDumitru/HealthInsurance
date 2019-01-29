using HealthInsurance.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthInsurance.Core.Interfaces.Specifications
{
	public interface IRepository
    {
		Task<T> GetById<T>(int id) where T : BaseIdentity;
		Task<T> GetSingleBySpecification<T>(ISpecification<T> spec) where T : BaseIdentity;
		Task<IReadOnlyList<T>> GetAll<T>() where T : BaseIdentity;
		Task<IReadOnlyList<T>> GetBySpecification<T>(ISpecification<T> spec) where T : BaseIdentity;
		Task<int> Count<T>(ISpecification<T> spec) where T : BaseIdentity;
		Task<T> Add<T>(T entity) where T : BaseIdentity;
		void Update<T>(T entity) where T : BaseIdentity;
		void Delete<T>(T entity) where T : BaseIdentity;
	}
}
