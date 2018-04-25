using System;
using Apache.Ignite.Core;
using Apache.Ignite.Core.Cache;
using Apache.Ignite.Core.PersistentStore;

using Opta.Services.IActor;

namespace samp2
{
    class Program
    {
        [STAThread]
        public static void Main()
        {
            using (var ignite = Ignition.StartFromApplicationConfiguration())
            {

            }
        }
    }
}
