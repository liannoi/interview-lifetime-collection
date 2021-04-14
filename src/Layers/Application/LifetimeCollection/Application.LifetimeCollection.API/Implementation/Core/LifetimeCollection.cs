using System.Collections;
using System.Collections.Generic;
using System.Linq;
using LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces;
using LifetimeCollection.Domain.API.Common.Entities;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core
{
    public partial class LifetimeCollection<TEntity> : ILifetimeCollection<TEntity>
    {
        private readonly int _lifetimeSeconds;
        private readonly IList<LifetimeEntity<TEntity>> _list;

        public LifetimeCollection(int lifetimeSeconds = LifetimeCollectionOptions.LifetimeInSeconds)
        {
            _list = new List<LifetimeEntity<TEntity>>();
            _lifetimeSeconds = lifetimeSeconds;
        }

        public int Count => _list.Count;
        public bool IsReadOnly => _list.IsReadOnly;

        public TEntity? this[int index]
        {
            get => GetByIndex(index);
            set => Insert(index, value!);
        }

        public void Add(TEntity entity)
        {
            var wrapped = WrapInLifetime(entity);
            _list.Add(wrapped);
            OnItemAvailable(new ItemAvailableEvent<TEntity> {AvailableEntity = wrapped});
        }

        public void Clear()
        {
            _list.Clear();
        }

        public int IndexOf(TEntity entity)
        {
            return _list.IndexOf(WrapInLifetime(entity));
        }

        public void Insert(int index, TEntity entity)
        {
            var wrapped = WrapInLifetime(entity);
            _list.Insert(CheckIndex(index), wrapped);
            OnItemAvailable(new ItemAvailableEvent<TEntity> {AvailableEntity = wrapped});
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
            _list.CopyTo(array.Select(WrapInLifetime).ToArray(), index);
        }

        public bool Remove(TEntity entity)
        {
            return _list.Remove(WrapInLifetime(entity));
        }

        public IEnumerator GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}