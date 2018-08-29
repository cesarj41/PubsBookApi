using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CaribeMediaApi.Extensions
{
    public static class PaginationQueriableExtension
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, Pagination paging)
        {
            if (paging == null || 
                !paging.PageNumber.HasValue || !paging.PageSize.HasValue)
                return query;
            return 
                query.Skip(paging.PageSize.Value * (paging.PageNumber.Value - 1))
                     .Take(paging.PageSize.Value);
        }

    }
    public class Pagination
    {
        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "pageNumber should be a number and greater than 0.")]
        public int? PageNumber { get; set; }

        [RegularExpression("^[1-9][0-9]*$", ErrorMessage = "pageSize should be a number and greater than 0.")]
        public int? PageSize { get; set; }
    }
}