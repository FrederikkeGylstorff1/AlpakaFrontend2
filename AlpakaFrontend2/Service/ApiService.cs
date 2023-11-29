using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AlpakaFrontend2.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient) 
        {  
            this._httpClient = httpClient; 
        }


        public async Task<T> GetTAsync<T>(string endpoint)
        {
            return await _httpClient.GetFromJsonAsync<T>(endpoint); 
        }



    }
}
