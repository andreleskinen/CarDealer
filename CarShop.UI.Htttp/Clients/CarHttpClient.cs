using System.Collections.Generic;
using System.Text.Json;

namespace CarShop.UI.Htttp.Clients;

public class CarHttpClient
{
    private readonly HttpClient _httpClient;
    string _baseAdress = "https://localhost:5000/api/";

    public CarHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri($"{_baseAdress}category");
    }

    public async Task<List<CategoryGetDTO>> GetCategoryAsync(int categoryId)
    {
        try
        {
            // Use the relative path, not the base address here
            string relativePath = $"categoriesbycategory/{categoryId}";
            using HttpResponseMessage response = await _httpClient.GetAsync(relativePath);
            response.EnsureSuccessStatusCode();

            var resultStream = await response.Content.ReadAsStreamAsync();
            var result = await JsonSerializer.DeserializeAsync<List<CategoryGetDTO>>(resultStream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result ?? [];
        }
        catch (Exception ex)
        {
            return [];
        }
    }

}
