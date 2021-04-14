using System;
using LifetimeCollection.Domain.API.Common.Lifetime;

namespace LifetimeCollection.Domain.API.Events.Lifetime
{
    public class ItemUnavailableEvent<TEntity> : EventArgs
    {
        public LifetimeEntity<TEntity> LifetimeEntity { get; set; } = null!;
    }
}