using System;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.PersistentStore;

using Opta.Services.ActorService;
using Opta.Services.IActor;

namespace samp1
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var ignite = Ignition.StartFromApplicationConfiguration())
            {
                Console.WriteLine(">>> Services example started.");
                Console.WriteLine();

                // Deploy a service
                var svc = new ActorService<int, string>();
                Console.WriteLine(">>> Deploying service to all nodes...");
                ignite.GetServices().DeployNodeSingleton("service", svc);

                // Get a sticky service proxy so that we will always be contacting the same remote node.
                var prx = ignite.GetServices().GetServiceProxy<IActorService<int, string>>("service", true);

                for (var i = 0; i < 10; i++)
                    prx.Put(i, i.ToString());

                var mapSize = prx.Size;

                Console.WriteLine(">>> Map service size: " + mapSize);

                ignite.GetServices().CancelAll();
            }

            Console.WriteLine();
            Console.WriteLine(">>> Example finished, press any key to exit ...");
            Console.ReadKey();
        }
    }

    //static void Main(string[] args)
    //{
    //    Console.WriteLine("Hello World!");

    //    var cfg = new IgniteConfiguration
    //    {
    //        // Включить хранение данных на диске
    //        PersistentStoreConfiguration = new PersistentStoreConfiguration()
    //    };

    //    var ignite = Ignition.Start(cfg);
    //    ignite.SetActive(true);  // Явная активация необходима при включённом persistence

    //    ICache<int, Car> cache = ignite.GetOrCreateCache<int, Car>("cars");
    //    // cache[1] = new Car { Model = "Pagani Zonda R", Power = 740 };

    //    foreach (ICacheEntry<int, Car> entry in cache)
    //        Console.WriteLine(entry);

    //    Console.ReadKey();
    //}

}
