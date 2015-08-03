using System;
using System.Collections.Generic;

namespace Loot
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> TakeWhileAggregate<T, TAggregate>(this IEnumerable<T> items,
            Func<T, TAggregate, TAggregate> accumulator, Func<TAggregate, bool> predicate, TAggregate seed)
        {
            var aggregate = seed;

            foreach (var item in items)
            {
                if (predicate(aggregate))
                {
                    yield return item;
                }
                else
                {
                    yield break;
                }

                aggregate = accumulator(item, aggregate);
            }
        }

        public static IEnumerable<T> TakeWhileAggregate<T, TAggregate>(this IEnumerable<T> items, Func<T, TAggregate, TAggregate> accumulator, Func<TAggregate, bool> predicate)
        {
            var seed = Activator.CreateInstance<TAggregate>();

            return TakeWhileAggregate(items, accumulator, predicate, seed);
        }  
    }
}