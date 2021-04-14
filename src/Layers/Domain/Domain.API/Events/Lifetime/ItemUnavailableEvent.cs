using System;
using LifetimeCollection.Domain.API.Common.Entities;

namespace LifetimeCollection.Domain.API.Events.Lifetime
{
    public class ItemUnavailableEvent<TEntity> : EventArgs
    {
        public LifetimeEntity<TEntity> LifetimeEntity { get; set; } = null!;
    }
}