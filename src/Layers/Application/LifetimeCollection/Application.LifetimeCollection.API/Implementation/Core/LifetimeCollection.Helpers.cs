using System;
using System.Collections.Generic;
using LifetimeCollection.Application.LifetimeCollection.API.Extensions;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core
{
    public sealed partial class LifetimeCollection<TEntity>
    {
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return (IEnumerator<TEntity>) _list.GetEnumerator();
        }

        private TEntity? GetIfAvailable(int index)
        {
            var model = _list[index];

            var itemAvailable = model.AddedTime.Second + _lifetimeSeconds >= DateTime.Now.Second;
            if (itemAvailable) return model.Entity;

            OnItemUnavailable(new ItemUnavailableEvent<TEntity> {LifetimeEntity = model});

            return default;
        }

        private int CheckIndex(int index)
        {
            return index.ThrowIfOutOfRange(_list.Count);
        }
    }
}