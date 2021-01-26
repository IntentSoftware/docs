using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.Entities.Repositories.Api.Interface", Version = "1.0")]

namespace MyCompany.MyMovies.Domain
{
    public interface IRepository<TDomain, TPersistence>
    {
        void Add(TDomain entity);
        void Remove(TDomain entity);
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        Task<TDomain> FindAsync(Expression<Func<TPersistence, bool>> filterExpression);
        Task<List<TDomain>> FindAllAsync();
        Task<List<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression);
        Task<IPagedResult<TDomain>> FindAllAsync(int pageIndex, int pageSize);
        Task<IPagedResult<TDomain>> FindAllAsync(Expression<Func<TPersistence, bool>> filterExpression, int pageIndex, int pageSize);
        Task<int> CountAsync(Expression<Func<TPersistence, bool>> filterExpression);
        Task<bool> AnyAsync(Expression<Func<TPersistence, bool>> filterExpression);
    }
}