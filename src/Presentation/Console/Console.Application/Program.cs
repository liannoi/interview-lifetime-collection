using System.Threading.Tasks;
using LifetimeCollection.Application.LifetimeCollection.API;
using LifetimeCollection.Application.LifetimeCollection.API.Common.Interfaces;
using LifetimeCollection.Application.LifetimeCollection.API.Implementation.Core;
using LifetimeCollection.Domain.API.Entities;
using LifetimeCollection.Domain.API.Events.Lifetime;

namespace LifetimeCollection.Presentation.Console.Application
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            //
            // 1.1. Create a collection of integer values.
            //
            ILifetimeCollection<int> ints = new LifetimeCollection<int>();

            //
            // 1.2. Subscribe to event handling.
            //
            ints.ItemAvailable += OnItemAvailable;
            ints.ItemUnavailable += OnItemUnavailable;

            //
            // 1.3. Adding values.
            //
            ints.Add(1);
            ints.Add(2);
            ints.Add(3);

            //
            // 1.4. Delay.
            //
            await Task.Delay(LifetimeCollectionOptions.LifetimeInSeconds * 1000);

            //
            // 1.5. We are trying to get the first element, which should already be inactive (due to a delay).
            //
            System.Console.WriteLine($"Get: {ints[0]}");

            //
            // 2.1. Create a collection with reference types.
            //
            ILifetimeCollection<Person> persons = new LifetimeCollection<Person>();

            //
            // 2.2. Subscribe to event handling.
            //
            persons.ItemAvailable += OnPersonAvailable;
            persons.ItemUnavailable += OnPersonUnavailable;

            //
            // 2.3. Adding values.
            //
            persons.Add(new Person {Id = 1, FirstName = "Barbara", LastName = "Smith"});
            persons.Add(new Person {Id = 2, FirstName = "Gerald", LastName = "Sears"});
            persons.Add(new Person {Id = 3, FirstName = "Vincenzo", LastName = "Osterman"});

            //
            // 2.4. We are trying to immediately read the information about the first person.
            //
            System.Console.WriteLine($"Get: {persons[0]}");

            //
            // 2.5. Delay.
            //
            await Task.Delay(LifetimeCollectionOptions.LifetimeInSeconds * 1000);

            //
            // 2.6. We are trying to get the first person, which should already be inactive (due to a delay).
            //
            System.Console.WriteLine($"Get: {persons[0]}");
        }

        // Event handling.

        private static void OnItemAvailable(object? sender, ItemAvailableEvent<int> e)
        {
            System.Console.WriteLine($"OnItemAvailable: {e.AvailableEntity.Entity}");
        }

        private static void OnItemUnavailable(object? sender, ItemUnavailableEvent<int> e)
        {
            System.Console.WriteLine($"OnItemUnavailable: {e.UnavailableEntity.Entity}");
        }

        private static void OnPersonUnavailable(object? sender, ItemUnavailableEvent<Person> e)
        {
            System.Console.WriteLine($"OnPersonUnavailable: {e.UnavailableEntity.Entity}");
        }

        private static void OnPersonAvailable(object? sender, ItemAvailableEvent<Person> e)
        {
            System.Console.WriteLine($"OnPersonAvailable: {e.AvailableEntity.Entity}");
        }
    }
}