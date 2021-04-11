using System;
using System.Collections.Generic;
using System.Linq;

namespace Flextensions
{
    public static class Differentiate
    {

        /// <summary>
        /// Create a tuple missing entry apposed to the other side. Example:
        /// <example>
        /// <code>
        /// <para/>| 1 | 2 | 3 | 
        /// <para/>| 1 | 2 | 3 | 4 |
        /// </code>
        /// in this case the left hand side contains one entry: 4, since it misses that entry apposed to the right hand side
        /// </example>
        /// </summary>
        /// <param name="left">the original list</param>
        /// <param name="right">the list to differ on</param>
        /// <param name="identifier">the select to identify a unique entry</param>
        /// <returns></returns>
        public static Tuple<IEnumerable<T>, IEnumerable<T>> Differ<T, TKey>(this IEnumerable<T> left, IEnumerable<T> right, Func<T, TKey> identifier)
        {
            var leftList = left.ToDictionary(identifier, e => e);
            var rightList = right.ToDictionary(identifier, e => e);

            return new Tuple<IEnumerable<T>, IEnumerable<T>>(
                from rightKeyPair in rightList where !leftList.ContainsKey(rightKeyPair.Key) select rightKeyPair.Value,
                from leftKeyPair in leftList where !rightList.ContainsKey(leftKeyPair.Key) select leftKeyPair.Value
            );
        }
    }
}
