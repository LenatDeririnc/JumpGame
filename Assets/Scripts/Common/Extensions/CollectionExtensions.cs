using System.Collections.Generic;

namespace Common.Extensions
{
    public static class CollectionExtensions
    {
        public static void RemoveIfContains<T>(this ICollection<T> hashSet, T obj)
        {
            if (hashSet.Contains(obj))
                hashSet.Remove(obj);
        }
    }
}