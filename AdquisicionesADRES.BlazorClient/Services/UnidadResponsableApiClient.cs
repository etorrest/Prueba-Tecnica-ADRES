using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdquisicionesADRES.BlazorClient.Models;

namespace AdquisicionesADRES.BlazorClient.Services
{
    public class UnidadResponsableApiClient
    {
        private readonly HttpClient _httpClient;

        public UnidadResponsableApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UnidadResponsableDto>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<UnidadResponsableDto>>("UnidadResponsable");
        }

        public async Task<UnidadResponsableDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<UnidadResponsableDto>($"UnidadResponsable/{id}");
        }

        public async Task<UnidadResponsableDto?> CreateAsync(UnidadResponsableDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("UnidadResponsable", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<UnidadResponsableDto>();
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int id, UnidadResponsableDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"UnidadResponsable/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"UnidadResponsable/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
