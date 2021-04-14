# Lifetime Collection

[![Codacy](https://app.codacy.com/project/badge/Grade/f877a070a8414445a2050201a62375d4)](https://www.codacy.com/gh/liannoi/interview-lifetime-collection/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=liannoi/interview-lifetime-collection&amp;utm_campaign=Badge_Grade)
[![Code Climate](https://api.codeclimate.com/v1/badges/f5998d72a0946bc9c922/maintainability)](https://codeclimate.com/github/liannoi/interview-lifetime-collection/maintainability)
[![CodeFactor](https://www.codefactor.io/repository/github/liannoi/interview-lifetime-collection/badge)](https://www.codefactor.io/repository/github/liannoi/interview-lifetime-collection)
[![Codebeat](https://codebeat.co/badges/f3c4c308-bcf6-40cd-9ac4-d06fcafd2ac8)](https://codebeat.co/projects/github-com-liannoi-interview-lifetime-collection-main)
[![BetterCode](https://bettercodehub.com/edge/badge/liannoi/interview-lifetime-collection?branch=main)](https://bettercodehub.com/)

Implementing a custom collection that tracks and manages the lifetime of every
item added to it. I tried to perform this task as if it were part of some
business task, at the same time, so that it would be convenient to work with the
library as with some kind of NuGet package. Also, the task was to **cover the
code with tests**, but due to a lack of knowledge in this direction, I postponed
this certainly important part.

## Example

```csharp
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
```

### Output

```
OnItemAvailable: 1
OnItemAvailable: 2
OnItemAvailable: 3
OnItemUnavailable: 1
Get: 0
OnPersonAvailable: (1) Barbara Smith
OnPersonAvailable: (2) Gerald Sears
OnPersonAvailable: (3) Vincenzo Osterman
Get: (1) Barbara Smith
OnPersonUnavailable: (1) Barbara Smith
Get: 
```

## License

This repository is licensed under [Apache-2.0](https://github.com/liannoi/interview-lifetime-collection/blob/main/LICENSE).

[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Fliannoi%2Finterview-lifetime-collection.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Fliannoi%2Finterview-lifetime-collection?ref=badge_large)

```
Copyright 2021 Maksym Liannoi

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

   http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
```
