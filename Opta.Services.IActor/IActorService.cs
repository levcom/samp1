using System;
using System.Collections.Generic;
using System.Text;

using Apache.Ignite.Core.Services;

namespace Opta.Services.IActor
{
    public interface IActorService<TK, TV> : IService
    {
        /// <summary>
        /// Puts an entry to the map.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        void Put(TK key, TV value);

        /// <summary>
        /// Gets an entry from the map.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>Entry value.</returns>
        TV Get(TK key);

        /// <summary>
        /// Clears the map.
        /// </summary>
        void Clear();

        /// <summary>
        /// Gets the size of the map.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        int Size { get; }
    }

}
