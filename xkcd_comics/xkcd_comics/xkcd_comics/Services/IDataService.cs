using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xkcd_comics.Models;

namespace xkcd_comics.Services
{
    public interface IDataService<T>
    {
        Comic GetComicAsync(int id);
    }
}
