
using Assessment.Application.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Assessment.Application.Helpers
{
    /// <summary>
    /// Create a new object with properties of the current object
    /// </summary>
    /// 
    public static class PaginationExtention
    {
        public static PaginationResult<IQueryable<T>> ToPagedResponse<T>(this IQueryable<T> record, PaginationFilter filter)
        {
            filter.PageNumber = filter.PageNumber == 0 ? 0 : filter.PageNumber - 1;
            var response = record.Skip(filter.PageNumber * filter.PageSize).Take(filter.PageSize);
            var count = record.Count();
            var totalPages = count % filter.PageSize == 0 ? count / filter.PageSize : count / filter.PageSize + 1;
            return PaginationResult<IQueryable<T>>.Success(response, totalPages, count);
        }
    }
}
