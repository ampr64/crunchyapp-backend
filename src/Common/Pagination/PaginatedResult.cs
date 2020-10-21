using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrunchyAppBackend.Common.Pagination
{
    public class PaginatedResult<T>
    {
        private PaginatedResult(List<T> items, int pageIndex, int totalPages)
        {
            PageIndex = pageIndex;
            TotalPages = totalPages;

            Results = items;
        }

        public bool HasNext => PageIndex < TotalPages;
        public bool HasPrevious => PageIndex > 1;
        public int PageIndex { get; }
        public int TotalPages { get; }
        public List<T> Results { get; }

        public static async Task<PaginatedResult<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            int count = await source.CountAsync();
            int maxSize = 100;

            pageSize = (pageSize > maxSize || pageSize < 1) ? maxSize : pageSize;
            int totalPages = count > 0 ? (int)Math.Ceiling(count / (double)pageSize) : 1;
            pageIndex = pageIndex > totalPages ? totalPages : pageIndex;
            
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new PaginatedResult<T>(items, pageIndex, totalPages);
            return result;
        }
    }
}