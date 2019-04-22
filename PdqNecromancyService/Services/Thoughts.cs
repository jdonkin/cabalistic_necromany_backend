using PdqNecromancyService.Interfaces;
using PdqNecromancyService.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PdqNecromancyService.Services
{
    public class Thoughts : IThought
    {
        private readonly HttpClient _client = new HttpClient();

        public async Task<ServiceThoughtsModel> GetThoughts()
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync("https://pdqweb.azurewebsites.net/api/brain");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServiceThoughtsModel>(responseBody);
            }
            catch(Exception e)
            {
                Console.WriteLine(e); //todo: handle this
            }

            return new ServiceThoughtsModel();
        }

    }
}
