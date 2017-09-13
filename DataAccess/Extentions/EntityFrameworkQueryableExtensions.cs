using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Stockpot.DataAccess.Extentions
{
    internal static class EntityFrameworkQueryableExtensions
    {
        public static IQueryable<TEntity> SetTracking<TEntity>(this IQueryable<TEntity> source, bool tracking) where TEntity : class
        {
            if (tracking)
            {
                return source.AsTracking();
            }

            return source.AsNoTracking();
        }
    }
}
