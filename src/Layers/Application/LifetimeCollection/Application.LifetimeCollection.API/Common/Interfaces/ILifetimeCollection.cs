using System.Collections.Generic;

namespace LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces
{
    public interface ILifetimeCollection<TEntity> : IList<TEntity>, INotifyItemAvailable<TEntity>,
        INotifyItemUnavailable<TEntity>
    {
    }
}