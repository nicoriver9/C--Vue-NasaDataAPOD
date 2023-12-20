using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

public class NasaApodService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public NasaApodService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

     public async Task<List<NasaApodResponse>> GetApodListAsync(int count)
    {
        string apiKey = _configuration["NasaApiKey"];
        string apiUrl = $"https://api.nasa.gov/planetary/apod?api_key={apiKey}&count={count}";

        var response = await _httpClient.GetStringAsync(apiUrl);

        return ParseApodListResponse(response);
    }

    private List<NasaApodResponse> ParseApodListResponse(string json)
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
        };

        return JsonSerializer.Deserialize<List<NasaApodResponse>>(json, options) ?? new List<NasaApodResponse>();
    }
}
