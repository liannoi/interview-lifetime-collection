using System;
using LifetimeCollection.Domain.API.Common.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Extensions
{
    public static class LifetimeExtensions
    {
        public static LifetimeEntity<TEntity> WrapLifetime<TEntity>(this TEntity self)
        {
            return new() {Entity = self.ThrowIfNull(), AddedTime = DateTime.Now};
        }
    }
}