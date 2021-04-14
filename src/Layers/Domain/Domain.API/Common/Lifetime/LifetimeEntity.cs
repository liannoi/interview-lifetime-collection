using System;

namespace LifetimeCollection.Domain.API.Common.Lifetime
{
    public class LifetimeEntity<TEntity>
    {
        public TEntity Entity { get; set; }
        public DateTime AddedTime { get; set; }
    }
}