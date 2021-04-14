using System;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces
{
    public interface INotifyItemUnavailable<TEntity>
    {
        public event EventHandler<ItemUnavailableEvent<TEntity>> ItemUnavailable;
    }
}