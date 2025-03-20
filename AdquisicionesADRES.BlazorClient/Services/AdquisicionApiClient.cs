using System.Net.Http.Json;
using AdquisicionesADRES.BlazorClient.Models;

public class AdquisicionApiClient
{
    private readonly HttpClient _http;

    public AdquisicionApiClient(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<AdquisicionDto>?> GetAllAsync()
    {
        return await _http.GetFromJsonAsync<List<AdquisicionDto>>("Adquisiciones");
    }

    public async Task<AdquisicionDto?> GetByIdAsync(Guid id)
    {
        return await _http.GetFromJsonAsync<AdquisicionDto>($"Adquisiciones/{id}");
    }

    public async Task<AdquisicionDto?> CreateAsync(AdquisicionDto dto)
    {
        var response = await _http.PostAsJsonAsync("Adquisiciones", dto);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<AdquisicionDto>();
        return null;
    }

    public async Task<bool> UpdateAsync(Guid id, AdquisicionDto dto)
    {
        var response = await _http.PutAsJsonAsync($"Adquisiciones/{id}", dto);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var response = await _http.DeleteAsync($"Adquisiciones/{id}");
        return response.IsSuccessStatusCode;
    }
}
