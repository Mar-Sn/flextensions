using System;
using System.Collections.Generic;
using System.Linq;

namespace Flextensions
{
    public static class Merge
    {
        public static IEnumerable<T> MergeUnique<T, TKey>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, TKey> identifier)
        {
            var l = left.ToDictionary(identifier, e => e);
            var r = right.ToDictionary(identifier, e => e);
            foreach (var key in r.Keys.Where(key => !l.ContainsKey(key)))
            {
                l[key] = r[key];
            }

            return l.Values;
        }
    }
}
