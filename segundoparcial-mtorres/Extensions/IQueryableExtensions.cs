using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using segundoparcial_mtorres.Helpers;
using segundoparcial_mtorres.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.Extensions
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

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, params string[] propertiesNames)
        {
            var selectors = new List<Expression<Func<T, object>>>();
            foreach (var propertyName in propertiesNames)
            {
                selectors.Add(ExpressionBuilder.BuildPropertyAccessExpression<T>(propertyName));
            }
            return source.OrderBy(selectors.ToArray());
        }

        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, params Expression<Func<T, object>>[] selectors)
        {
            IOrderedQueryable<T> result = null;
            if (selectors != null && selectors.Any())
            {
                result = source.OrderBy(keySelector: selectors.First());
                if (selectors.Length > 1)
                {
                    result = selectors.Skip(1).Aggregate(result, (current, selector) => result.ThenBy(selector));
                }
            }

            return result;
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, params string[] propertiesNames)
        {
            var selectors = new List<Expression<Func<T, object>>>();
            foreach (var propertyName in propertiesNames)
            {
                selectors.Add(ExpressionBuilder.BuildPropertyAccessExpression<T>(propertyName));
            }
            return source.OrderByDescending(selectors.ToArray());
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, params Expression<Func<T, object>>[] selectors)
        {
            IOrderedQueryable<T> result = null;
            if (selectors != null && selectors.Any())
            {
                result = source.OrderByDescending(selectors.First());
                if (selectors.Length > 1)
                {
                    result = selectors.Skip(1).Aggregate(result, (current, selector) => result.ThenByDescending(selector));
                }
            }

            return result;
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propertyName)
            => source.ThenBy(ExpressionBuilder.BuildPropertyAccessExpression<T>(propertyName));

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string propertyName)
            => source.ThenByDescending(ExpressionBuilder.BuildPropertyAccessExpression<T>(propertyName));

        #endregion
    }
}