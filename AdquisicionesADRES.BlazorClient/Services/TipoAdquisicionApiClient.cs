using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using AdquisicionesADRES.BlazorClient.Models; // Ajusta el namespace donde estén tus DTOs

namespace AdquisicionesADRES.BlazorClient.Services
{
    public class TipoAdquisicionApiClient
    {
        private readonly HttpClient _httpClient;

        public TipoAdquisicionApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // GET ALL
        public async Task<List<TipoAdquisicionDto>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<TipoAdquisicionDto>>("TipoAdquisicion");
        }

        // GET BY ID
        public async Task<TipoAdquisicionDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TipoAdquisicionDto>($"TipoAdquisicion/{id}");
        }

        // CREATE
        public async Task<TipoAdquisicionDto?> CreateAsync(TipoAdquisicionDto dto)
        {
            var response = await _httpClient.PostAsJsonAsync("TipoAdquisicion", dto);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<TipoAdquisicionDto>();
            }
            return null;
        }

        // UPDATE
        public async Task<bool> UpdateAsync(int id, TipoAdquisicionDto dto)
        {
            var response = await _httpClient.PutAsJsonAsync($"TipoAdquisicion/{id}", dto);
            return response.IsSuccessStatusCode;
        }

        // DELETE
        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"TipoAdquisicion/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
