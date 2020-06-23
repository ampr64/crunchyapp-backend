using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace segundoparcial_mtorres.Helpers
{
    public static class ExpressionBuilder
    {
        public static Expression<Func<T, object>> BuildPropertyAccessExpression<T>(string propertyName)
        {
            Expression<Func<T, object>> selector = null;
            var entityType = typeof(T);
            var parameter = Expression.Parameter(entityType, entityType.Name);
            var body = Expression.PropertyOrField(parameter, propertyName);
            if (body != null)
            {
                selector = Expression.Lambda<Func<T, object>>(body, parameter);
            }

            return selector;
        }
    }
}