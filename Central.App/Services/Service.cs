using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Central.App.Services
{
    public class Service
    {
        HttpClient Client;
        List<Monkey> Items = new();

        public Service()
        {
            this.Client = new HttpClient();
        }

        public async Task<List<Monkey>> Gets()
        {
            if (this.Items?.Count > 0) return this.Items;

            //--------Reading from Url--------------------------------------------------//
            var url = "https://montemagno.com/monkeys.json";
            var response = await this.Client.GetAsync(url);
            if (response.IsSuccessStatusCode) {
                this.Items = await response.Content.ReadFromJsonAsync<List<Monkey>>();
            }


            /*
            //--------Reading from local Json File--------------------------------------//
            using var stream = await FileSystem.OpenAppPackageFileAsync("monkey.json");
            using var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            this.Items = JsonSerializer.Deserialize<List<Monkey>>(contents);
            */

            return this.Items;
        }
    }
}
