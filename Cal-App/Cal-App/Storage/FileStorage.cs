using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.Storage
{
    /// <summary>
    /// Implements a storage 
    /// </summary>
    /// <typeparam name="TModel">The model of the storage</typeparam>
    class FileStorage<TModel> : IStorage<TModel>
    {
        /// <summary>
        /// Gets the stored model
        /// </summary>
        /// <param name="path">The path of the file with the stored model</param>
        /// <returns>The model of the storage or null if does not exist the file</returns>
        public TModel GetModel(string path)
        {
            return JsonConvert.DeserializeObject<TModel>(File.ReadAllText(path));
        }
        /// <summary>
        /// Sets the stored model
        /// </summary>
        /// <param name="path">The path of the file with the stored model</param>
        /// <param name="model">The model of the storage</param>
        public void SetModel(string path, TModel model)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(model));
        }
    }
}
