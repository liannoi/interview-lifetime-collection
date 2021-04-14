using System;
using System.Collections.Generic;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces
{
    public interface ILifetimeCollection<TEntity> : IList<TEntity>
    {
        public event EventHandler<ItemUnavailableEvent<TEntity>> ItemUnavailable;
    }
}