using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using xkcd_comics.Models;

namespace xkcd_comics.Services
{
    class DataService : IDataService<Comic>
    {
        public Comic GetComicAsync(int id)
        {
            string url = $"https://xkcd.com/{id}/info.0.json";         
            var client = new HttpClient();

            var response = client.GetAsync(url);
            var result = response.Result;

            string json = result.Content.ReadAsStringAsync().Result;

            var comic = JsonConvert.DeserializeObject<Comic>(json);

            return comic;
        }
    }
}
