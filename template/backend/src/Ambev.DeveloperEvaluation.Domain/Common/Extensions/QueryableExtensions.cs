using System.Linq.Expressions;

namespace Ambev.DeveloperEvaluation.Domain.Common.Extensions;

public static class QueryableExtensions
{
    public static IOrderedQueryable<T> OrderByDynamic<T>(this IQueryable<T> source, string ordering)
    {
        var parameters = ordering.Split(',');

        IOrderedQueryable<T>? result = null;

        foreach (var param in parameters)
        {
            var parts = param.Trim().Split(' ');
            var propertyName = parts[0];
            var descending = parts.Length > 1 && parts[1].ToLower() == "desc";

            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, propertyName);
            var lambda = Expression.Lambda(property, parameter);

            var methodName = result == null
                ? (descending ? "OrderByDescending" : "OrderBy")
                : (descending ? "ThenByDescending" : "ThenBy");

            var method = typeof(Queryable).GetMethods()
                .First(m => m.Name == methodName && m.GetParameters().Length == 2)
                .MakeGenericMethod(typeof(T), property.Type);

            result = (IOrderedQueryable<T>)method.Invoke(null, new object[] { result ?? source, lambda })!;
        }

        return result ?? (IOrderedQueryable<T>)source;
    }
}
