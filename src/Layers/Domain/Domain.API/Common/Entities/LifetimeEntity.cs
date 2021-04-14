using System;

namespace LifetimeCollection.Domain.API.Common.Entities
{
    public class LifetimeEntity<TEntity>
    {
        public TEntity Entity { get; set; }
        public DateTime AddedTime { get; set; }

        public bool IsAvailable(int lifetimeSeconds)
        {
            return AddedTime.Second + lifetimeSeconds > DateTime.Now.Second;
        }
    }
}