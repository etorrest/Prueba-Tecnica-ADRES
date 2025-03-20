using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdquisicionesADRES.BlazorClient.Models;

namespace AdquisicionesADRES.BlazorClient.Services
{
    public class EstadoAdquisicionApiClient
    {
        private readonly HttpClient _httpClient;

        public EstadoAdquisicionApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<EstadoAdquisicionDto>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<EstadoAdquisicionDto>>("EstadoAdquisicion");
        }

        public async Task<EstadoAdquisicionDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<EstadoAdquisicionDto>($"EstadoAdquisicion/{id}");
        }

        public async Task<EstadoAdquisicionDto?> CreateAsync(EstadoAdquisicionDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("EstadoAdquisicion", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<EstadoAdquisicionDto>();
            }
            return null;
        }

        public async Task<bool> UpdateAsync(int id, EstadoAdquisicionDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"EstadoAdquisicion/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"EstadoAdquisicion/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
