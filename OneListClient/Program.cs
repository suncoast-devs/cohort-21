using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ConsoleTables;

namespace OneListClient
{
    class Item
    {
        // Dear serializer, please use the field "id" for this
        [JsonPropertyName("id")]
        public int Id { get; set; }

        // Dear serializer, please use the field "text" for this
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("complete")]
        public bool Complete { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        public string CompletedStatus
        {
            get
            {
                // return      CONDITION    ?       VALUE WHEN TRUE           :       VALUE WHEN FALSE      
                return Complete ? "completed" : "not completed";
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();

            // let the token be the first argument to our program!
            var token = "";

            // If there are NO ARGUMENTS
            if (args.Length == 0)
            {
                // Ask the user for the token to use
                Console.Write("What list do you want? ");
                token = Console.ReadLine();
            }
            else
            {
                // Otherwise take the first one
                token = args[0];
            }

            var url = $"https://one-list-api.herokuapp.com/items?access_token={token}";

            var responseAsStream = await client.GetStreamAsync(url);

            var items = await JsonSerializer.DeserializeAsync<List<Item>>(responseAsStream);

            var table = new ConsoleTable("Description", "Created At", "Completed");

            foreach (var item in items)
            {
                table.AddRow(item.Text, item.CreatedAt, item.CompletedStatus);
            }

            table.Write();
        }
    }
}
