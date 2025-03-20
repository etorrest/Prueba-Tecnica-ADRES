
using AdquisicionesADRES.BlazorClient.Models;
using System.Net.Http.Json;

namespace AdquisicionesADRES.BlazorClient.Services
{
    public class ProveedorApiClient
    {
        private readonly HttpClient _httpClient;

        public ProveedorApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ProveedorDto>?> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<ProveedorDto>>("Proveedor");
        }

        public async Task<ProveedorDto?> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<ProveedorDto>($"Proveedor/{id}");
        }

        public async Task<ProveedorDto?> CreateAsync(ProveedorDto proveedor)
        {
            var response = await _httpClient.PostAsJsonAsync("Proveedor", proveedor);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProveedorDto>();
        }

        public async Task<bool> UpdateAsync(int id, ProveedorDto proveedor)
        {
            var response = await _httpClient.PutAsJsonAsync($"Proveedor/{id}", proveedor);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Proveedor/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
