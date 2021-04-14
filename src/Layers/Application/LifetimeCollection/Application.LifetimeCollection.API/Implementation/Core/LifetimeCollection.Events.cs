using System;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core
{
    public partial class LifetimeCollection<TEntity>
    {
        public event EventHandler<ItemAvailableEvent<TEntity>>? ItemAvailable;
        public event EventHandler<ItemUnavailableEvent<TEntity>>? ItemUnavailable;

        protected virtual void OnItemAvailable(ItemAvailableEvent<TEntity> e)
        {
            ItemAvailable?.Invoke(this, e);
        }

        protected virtual void OnItemUnavailable(ItemUnavailableEvent<TEntity> e)
        {
            ItemUnavailable?.Invoke(this, e);
        }
    }
}