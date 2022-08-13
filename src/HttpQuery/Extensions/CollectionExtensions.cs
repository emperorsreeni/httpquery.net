using System;

namespace HttpQuery.Extensions
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null) 
                return;
            foreach (var item in source)
            {
                action.Invoke(item);
            }
        }
    }
}
