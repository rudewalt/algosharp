using System;
using System.Collections.Generic;
using System.Linq;

namespace Algosharp.Infrastructure.Extensions
{
    public static class Linq
    {
        public static IEnumerable<TResult> DiffSelect<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TSource, bool, TResult> projection)
        {
            using (var iterator = source.GetEnumerator())
            {
                var isfirst = true;
                var previous = default(TSource);
                while (iterator.MoveNext())
                {
                    yield return projection(iterator.Current, previous, isfirst);
                    isfirst = false;
                    previous = iterator.Current;
                }
            }
        }
    }
}
