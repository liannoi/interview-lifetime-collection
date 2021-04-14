using System;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces
{
    public interface INotifyItemAvailable<TEntity>
    {
        public event EventHandler<ItemAvailableEvent<TEntity>> ItemAvailable;
    }
}