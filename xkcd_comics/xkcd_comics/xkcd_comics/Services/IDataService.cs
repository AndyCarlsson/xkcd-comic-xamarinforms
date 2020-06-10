using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace xkcd_comics.Services
{
    public interface IDataService<T>
    {
        String<T> GetItemAsync(string id);
    }
}
