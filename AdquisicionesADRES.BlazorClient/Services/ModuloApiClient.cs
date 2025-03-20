using AdquisicionesADRES.BlazorClient.Models;
using System.Net.Http.Json;

namespace AdquisicionesADRES.BlazorClient.Services
{
    public class ModuloApiClient
    {

        private readonly HttpClient _httpClient;
        public ModuloApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<ModuloDto>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ModuloDto>>("Modulo");
        }
    }
}
