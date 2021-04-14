using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core
{
    public sealed partial class LifetimeCollection<TEntity>
    {
        private void OnItemUnavailable(ItemUnavailableEvent<TEntity> e)
        {
            ItemUnavailable?.Invoke(this, e);
        }
    }
}