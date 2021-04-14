using System.Threading.Tasks;
using LifetimeCollection.Application.LifetimeCollection.API;
using LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Presentation.Console.Application
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var collection = new LifetimeCollection<int>();
            collection.ItemAvailable += OnItemAvailable;
            collection.ItemUnavailable += OnItemUnavailable;

            collection.Add(1);
            await Task.Delay(LifetimeCollectionOptions.LifetimeInSeconds * 1000);
            System.Console.WriteLine($"Get: {collection[0]}");
            collection.Insert(0, 11);
            System.Console.WriteLine($"Get: {collection[0]}");

            /*collection.Add(1);
            collection.Add(2);
            System.Console.WriteLine(collection.Contains(2));
            System.Console.WriteLine(collection.Contains(3));
            await Task.Delay(5000);
            collection.RemoveAt(0);
            System.Console.WriteLine($"Get: {collection[0]}");*/
        }

        private static void OnItemAvailable(object? sender, ItemAvailableEvent<int> e)
        {
            System.Console.WriteLine($"OnItemAvailable: {e.AvailableEntity.Entity}");
        }

        private static void OnItemUnavailable(object? sender, ItemUnavailableEvent<int> e)
        {
            System.Console.WriteLine($"OnItemUnavailable: {e.UnavailableEntity.Entity}");
        }
    }
}