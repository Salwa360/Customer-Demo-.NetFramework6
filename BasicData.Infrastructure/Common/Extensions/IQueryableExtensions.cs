using BasicDataOfCustomers.Infrastructure.DTOs;
using System.Linq.Expressions;

namespace BasicDataOfCustomers.Infrastructure.Common.Extensions
{
    public static class IQueryableExtensions
    {
        public static IEnumerable<TEntity> OrderBy<TEntity>(this IEnumerable<TEntity> query, Sorting sorting)
        {
            if (sorting == null || string.IsNullOrEmpty(sorting.Column))
                return query;

            string command = sorting.Direction.ToLower() == "desc" ? "OrderByDescending" : "OrderBy";
            var type = typeof(TEntity);
            var property = type.GetProperty(sorting.Column);
            if (property == null) return query;
            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExpression = Expression.Lambda(propertyAccess, parameter);
            var resultExpression = Expression.Call(typeof(Queryable), command, new Type[] { type, property.PropertyType },
                                          query.AsQueryable().Expression, Expression.Quote(orderByExpression));
            return query.AsQueryable().Provider.CreateQuery<TEntity>(resultExpression);
        }
    }
}
