using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Intent.RoslynWeaver.Attributes;
using Microsoft.EntityFrameworkCore;
using MyCompany.MyMovies.Domain;

[assembly: DefaultIntentManaged(Mode.Fully)]
[assembly: IntentTemplate("Intent.EntityFrameworkCore.Repositories.PagedList", Version = "1.0")]

namespace MyCompany.MyMovies.Infrastructure.Data
{
    public class PagedList<T> : List<T>, IPagedResult<T>
    {
        public int TotalCount { get; private set; }
        public int PageCount { get; private set; }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }

        public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
        {
            TotalCount = source.Count();
            PageCount = GetPageCount(pageSize, TotalCount);
            PageIndex = pageIndex;
            PageSize = pageSize;
            var skip = (PageIndex * PageSize);

            AddRange(source
                .Skip(skip)
                .Take(PageSize)
                .ToList());
        }

        public PagedList(int totalCount, int pageIndex, int pageSize, List<T> results)
        {
            TotalCount = totalCount;
            PageCount = GetPageCount(pageSize, TotalCount);
            PageIndex = pageIndex;
            PageSize = pageSize;
            AddRange(results);
        }

        public static Task<IPagedResult<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = source.CountAsync();
            var skip = (pageIndex * pageSize);
            var results = source
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
            return Task.WhenAll(count, results).ContinueWith<IPagedResult<T>>(x => new PagedList<T>(count.Result, pageIndex, pageSize, results.Result));
        }

        private int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return (totalCount / pageSize) + (remainder == 0 ? 0 : 1);
        }
    }
}
