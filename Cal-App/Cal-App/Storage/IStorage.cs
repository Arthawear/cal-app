using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.Storage
{
    /// <summary>
    /// Represents a storage
    /// </summary>
    /// <typeparam name="TModel">The model of the storage</typeparam>
    public interface IStorage<TModel>
    {
        /// <summary>
        /// Gets the stored model
        /// </summary>
        /// <param name="key">The name of the storage file</param>
        /// <returns>The model of the storage or null if does not exist the file</returns>
        TModel GetModel(string key);
        /// <summary>
        /// Sets the stored model
        /// </summary>
        /// <param name="key">The name of the storage file</param>
        /// <param name="model">The model of the storage</param>
        void SetModel(string key, TModel model);
    }
}
