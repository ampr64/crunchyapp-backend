using Microsoft.EntityFrameworkCore;
using segundoparcial_mtorres.Common.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> source, Expression<Func<TEntity, object>>[] navigationProperties)
            where TEntity : class
            => navigationProperties?.Aggregate(source, (query, property) => source?.Include(property));

        public static IQueryable<TEntity> IncludeMultiple<TEntity>(this IQueryable<TEntity> source, params string[] navigationProperties)
            where TEntity : class
            => navigationProperties?.Aggregate(source, (query, property) => source?.Include(property));

        public static Task<PaginatedResult<TDestination>> Paginate<TDestination>(this IQueryable<TDestination> source, int pageIndex, int pageSize)
            => PaginatedResult<TDestination>.CreateAsync(source, pageIndex, pageSize);

        #region Ordering Methods

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propertyName)
            => ApplyOrder(source, propertyName, nameof(OrderBy));

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string propertyName)
            => ApplyOrder(source, propertyName, nameof(OrderByDescending));

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
            => ApplyOrder(source, propertyName, nameof(ThenBy));

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
            => ApplyOrder(source, propertyName, nameof(ThenByDescending));


        private static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string propertyName, string methodName)
        {
            var entityType = typeof(T);
            var parameter = Expression.Parameter(entityType, entityType.Name);
            var body = Expression.PropertyOrField(parameter, propertyName);
            var selector = Expression.Lambda(body, parameter);

            return (IOrderedQueryable<T>)typeof(Queryable).GetMethods().SingleOrDefault(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(entityType, selector.Body.Type)
                    .Invoke(null, new object[] { source, selector });
        }

        #endregion
    }
}