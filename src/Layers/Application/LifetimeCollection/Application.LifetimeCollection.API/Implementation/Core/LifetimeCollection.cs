using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces;
using LifetimeCollection.Application.LifetimeCollection.API.Extensions;
using LifetimeCollection.Domain.API.Common.Entities;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core
{
    public sealed partial class LifetimeCollection<TEntity> : ILifetimeCollection<TEntity>
    {
        private readonly int _lifetimeSeconds;
        private readonly IList<LifetimeEntity<TEntity>> _list;

        public LifetimeCollection(int lifetimeSeconds = LifetimeCollectionOptions.LifetimeInSeconds)
        {
            _lifetimeSeconds = lifetimeSeconds;
            _list = new List<LifetimeEntity<TEntity>>();
        }

        public int Count => _list.Count;
        public bool IsReadOnly => _list.IsReadOnly;

        public TEntity this[int index]
        {
            get => GetIfAvailable(index)!;
            set => _list[index] = value.WrapLifetime();
        }

        public event EventHandler<ItemUnavailableEvent<TEntity>>? ItemUnavailable;

        public void Add(TEntity entity)
        {
            _list.Add(entity.WrapLifetime());
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int IndexOf(TEntity entity)
        {
            return _list.IndexOf(entity.WrapLifetime());
        }

        public void Insert(int index, TEntity entity)
        {
            _list.Insert(CheckIndex(index), entity.WrapLifetime());
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(CheckIndex(index));
        }

        public bool Contains(TEntity entity)
        {
            return _list.SingleOrDefault(e => EqualityComparer<TEntity>.Default.Equals(e.Entity, entity)) != null;
        }

        public void CopyTo(TEntity[] array, int index)
        {
            _list.CopyTo(array.Select(e => e.WrapLifetime()).ToArray(), index);
        }

        public bool Remove(TEntity entity)
        {
            return _list.Remove(entity.WrapLifetime());
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}