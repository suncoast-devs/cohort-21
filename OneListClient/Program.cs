using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace OneListClient
{
    class Item
    {
        public int id { get; set; }
        public string text { get; set; }
        public bool complete { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            var responseAsStream = await client.GetStreamAsync(
              "https://one-list-api.herokuapp.com/items?access_token=sdg-handbook"
            );

            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);

            foreach (var item in items)
            {
                Console.WriteLine($"The task {item.text} was created on {item.created_at} and has a completion of: {item.complete}");
            }

        }
    }
}
