using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using GymApp.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace GymApp.Services
{
    public class NewsService

    {
        private const string Url = "https://content.guardianapis.com/";
        private const string SearchEndpoint = "search?q=fitness/exercise/workout/gym/&api-key=";
        private const string apiKey = "24110167-6b86-4fc7-8546-bdae64e044ba";
        private HttpClient _client = new HttpClient();

        public async Task<List<News>> GetNews()
        {

            ObservableCollection<News> newsData = new ObservableCollection<News>();

            var response = await _client.GetAsync($"{Url}{SearchEndpoint}{apiKey}&page-size=30&order-by=relevance&show-fields=all");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var o = JsonConvert.DeserializeObject<RootObject>(content);

            foreach (var data in o.response.results)
            {
                newsData.Add(data);
            }
            return newsData.ToList();

        }

        public async Task<RootObject> GetContent(string id)
        {
            ObservableCollection<News> newsData = new ObservableCollection<News>();

            var response = await _client.GetAsync($"{Url}{id}?api-key={apiKey}&show-fields=all");

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;


            var content = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<RootObject>(content);
            return obj;
        }
    }
}
