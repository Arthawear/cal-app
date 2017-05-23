using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalApp.Storage
{
    public interface IStorage<TModel>
    {
        TModel GetModel(string key);
        void SetModel(string key, TModel model);
    }
}
