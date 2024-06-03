using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Guider.Application.Responses
{
    public class PaginatedList<TDest, TSource>
    {
        public IReadOnlyCollection<TDest> Items { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int TotalPages { get; }
        public int TotalCount { get; }

        public bool HasNextPage => (Page * PageSize) < TotalCount;
        public bool HasPreviousPage => Page > 1;

        public PaginatedList(IReadOnlyCollection<TDest> items, int page, int pageSize, int totalCount)
        {
            Items = items;
            Page = page;
            PageSize = pageSize;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            TotalCount = totalCount;
        }

        public static async Task<PaginatedList<TDest, TSource>> CreateAsync(IQueryable<TSource> query, IMapper mapper, int page, int pageSize)
        {
            var totalCount = await query.CountAsync();
            var sourceItems = await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            var destItems = mapper.Map<List<TDest>>(sourceItems);
            return new PaginatedList<TDest, TSource>(destItems, page, pageSize, totalCount);
        }

    }
}
