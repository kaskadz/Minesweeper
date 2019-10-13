using System;
using System.Collections.Generic;
using System.Linq;

namespace MineSweeper.Logic
{
    internal static class Extensions
    {
        public static IList<T> Shuffle<T>(this IList<T> list)
        {
            var rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
            return list;
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var obj in source)
            {
                action(obj);
            }
        }

        public static TSource RandomOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            Random r = new Random();
            var list = source.ToList();
            int sourceSize = list.Count;
            return list.Any() ? list.ElementAt(r.Next(sourceSize)) : default;
        }

        public static TSource Random<TSource>(this IEnumerable<TSource> source)
        {
            TSource randomElement = source.RandomOrDefault();

            if (randomElement.Equals(default(TSource)))
            {
                throw new InvalidOperationException("The source sequence is empty.");
            }

            return randomElement;
        }

        public static bool In<T>(this T value, params T[] values) where T : Enum
        {
            return values.Contains(value);
        }
    }
}