using PdqNecromancyService.Interfaces;
using PdqNecromancyService.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Threading;

namespace PdqNecromancyService.Services
{
    public class Thoughts : IThought
    {
        private readonly HttpClient _client = new HttpClient();
        static SemaphoreSlim semaphoreSlim = new SemaphoreSlim(1,1);
        private const string _thirdParyUrl = "https://pdqweb.azurewebsites.net/api/brain";

        public async Task<ServiceThoughtsModel> GetThoughts()
        {
            await semaphoreSlim.WaitAsync();
            try
            {
                HttpResponseMessage response = await _client.GetAsync(_thirdParyUrl);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ServiceThoughtsModel>(responseBody);
            }
            finally
            {
                semaphoreSlim.Release();
            }
        }

    }
}
