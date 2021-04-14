using System;

namespace LifetimeCollection.Application.LifetimeCollection.API.Extensions
{
    public static class ExceptionExtensions
    {
        public static TEntity ThrowIfNull<TEntity>(this TEntity self)
        {
            return self ?? throw new ArgumentNullException(nameof(self));
        }

        public static int ThrowIfOutOfRange(this int index, int count)
        {
            return index >= 0 && index < count
                ? index
                : throw new ArgumentOutOfRangeException(nameof(index),
                    "Index was out of range. Must be non-negative and less than the size of the collection.");
        }
    }
}