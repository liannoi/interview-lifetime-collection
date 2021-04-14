using System.Threading.Tasks;
using LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces;
using LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Presentation.Console.Application
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            ILifetimeCollection<int> collection = new LifetimeCollection<int>();
            collection.ItemUnavailable += OnItemUnavailable;

            collection.Add(1);
            collection.Add(2);
            System.Console.WriteLine(collection.Contains(2));
            System.Console.WriteLine(collection.Contains(3));
            //collection.RemoveAt(1);
            //await Task.Delay(5000);
            System.Console.WriteLine($"Get: {collection[0]}");
        }

        private static void OnItemUnavailable(object? sender, ItemUnavailableEvent<int> e)
        {
            var entity = e.LifetimeEntity.Entity;
            System.Console.WriteLine($"OnItemUnavailable: {entity}");
        }
    }
}