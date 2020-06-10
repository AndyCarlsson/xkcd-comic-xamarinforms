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
        public Task<Comic> GetItemAsync(string id)
        {
            string url = $"https://xkcd.com/{id}/info.0.json";
            
            var client = new HttpClient();

            var response = client.GetAsync(url);
            var result = response.Result;

            string comicString = result.Content.ReadAsStringAsync().Result;

            var comic = JsonConvert.DeserializeObject<Comic>(comicString);

            return Task.FromResult(comic);
        }
    }
}
