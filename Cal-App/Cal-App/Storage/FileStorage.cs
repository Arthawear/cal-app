using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.Storage
{
    class FileStorage<TModel> : IStorage<TModel>
    {
        public TModel GetModel(string path)
        {
            return JsonConvert.DeserializeObject<TModel>(File.ReadAllText(path));
        }

        public void SetModel(string path, TModel model)
        {
            File.WriteAllText(path, JsonConvert.SerializeObject(model));
        }
    }
}
