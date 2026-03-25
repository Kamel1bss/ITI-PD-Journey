using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ01;

internal static class Extensions
{
    // Filter
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> source, Predicate<T> pre)
    {
        foreach (var item in source)
        {
            if(pre(item))
                yield return item;
        }
    }

    // choose
    public static IEnumerable<TResult> Choose<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> chooser)
    {
        foreach (var item in source)
        {
            yield return chooser(item);
        }
    }
}
