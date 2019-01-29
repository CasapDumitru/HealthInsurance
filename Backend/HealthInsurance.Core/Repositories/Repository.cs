using HealthInsurance.Core.Data;
using HealthInsurance.Core.Interfaces.Specifications;
using HealthInsurance.Core.Entities;
using HealthInsurance.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthInsurance.Core.Repositories
{
	public class Repository : IRepository
	{
		private HealthInsuranceContext _context;

		public Repository(HealthInsuranceContext context)
		{
			_context = context;
		}

		public async Task<T> GetById<T>(int id) where T : BaseIdentity
		{
			return await _context.Set<T>().FindAsync(id);
		}

		public async Task<T> GetSingleBySpecification<T>(ISpecification<T> spec) where T : BaseIdentity
		{
			return await ApplySpecification(spec).FirstOrDefaultAsync();
		}

		public async Task<IReadOnlyList<T>> GetAll<T>() where T : BaseIdentity
		{
			return await _context.Set<T>().ToListAsync();
		}

		public async Task<IReadOnlyList<T>> GetBySpecification<T>(ISpecification<T> spec) where T : BaseIdentity
		{
			return await ApplySpecification(spec).ToListAsync();
		}

		public async Task<int> Count<T>(ISpecification<T> spec) where T : BaseIdentity
		{
			return await ApplySpecification(spec).CountAsync();
		}

		public async Task<T> Add<T>(T entity) where T : BaseIdentity
		{
			await _context.Set<T>().AddAsync(entity);
			return entity;
		}

		public void Update<T>(T entity) where T : BaseIdentity
		{
			_context.Set<T>().Update(entity);
		}

		public void Delete<T>(T entity) where T : BaseIdentity
		{
			_context.Set<T>().Remove(entity);
		}

		private IQueryable<T> ApplySpecification<T>(ISpecification<T> spec) where T : BaseIdentity
		{
			return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), spec); 
		}
	}
}
