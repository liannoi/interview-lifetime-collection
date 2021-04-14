using System;
using LifetimeCollection.Domain.API.Common.Entities;

namespace LifetimeCollection.Domain.API.Events.Lifetime
{
    public class ItemAvailableEvent<TEntity> : EventArgs
    {
        public LifetimeEntity<TEntity> AvailableEntity { get; set; } = null!;
    }
}