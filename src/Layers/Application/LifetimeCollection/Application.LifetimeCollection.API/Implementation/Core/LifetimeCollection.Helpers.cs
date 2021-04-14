using System;
using System.Collections.Generic;
using LifetimeCollection.Application.LifetimeCollection.API.Extensions;
using LifetimeCollection.Domain.API.Common.Entities;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core
{
    public partial class LifetimeCollection<TEntity>
    {
        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return (IEnumerator<TEntity>) _list.GetEnumerator();
        }

        private TEntity? GetByIndex(int index)
        {
            var model = _list[CheckIndex(index)];
            if (model.IsAvailable(_lifetimeSeconds)) return model.Entity;
            OnItemUnavailable(new ItemUnavailableEvent<TEntity> {UnavailableEntity = model});

            return default;
        }

        private int CheckIndex(int index)
        {
            return index.ThrowIfOutOfRange(_list.Count);
        }

        private LifetimeEntity<TEntity> WrapInLifetime(TEntity entity)
        {
            return new() {Entity = entity.ThrowIfNull(), AddedTime = DateTime.Now};
        }
    }
}