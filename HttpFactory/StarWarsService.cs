using System.Text.Json;
using static SwapiModels;

public class StarWarsService
{
    private readonly HttpClient _httpClient;

    public StarWarsService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("SwapiClient");
    }

    public async Task<SwapiPersonProperties> GetCharacterAsync(int id)
    {
        var response = await _httpClient.GetAsync($"people/{id}");
        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsStringAsync();

        var options = new JsonSerializerOptions {  PropertyNameCaseInsensitive = true };
        var result = JsonSerializer.Deserialize<SwapiPersonResponse>(content, options);

        return result?.Result?.Properties;
    }
}
