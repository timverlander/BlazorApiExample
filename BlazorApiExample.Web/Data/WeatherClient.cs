using BlazorApiExample.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;

namespace BlazorApiExample.Web.Data
{
    public class WeatherClient
    {
        private const string _apiWeatherPath = "http://localhost:5001/Weather/";
        private readonly HttpClient _httpClient;
        
        public WeatherClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async IAsyncEnumerable<WeatherForecast> GetWeatherForecastAsync()
        {
            var forecastsSerialized = await _httpClient.GetStringAsync(_apiWeatherPath).ConfigureAwait(false);

            var forecasts = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(forecastsSerialized, SerializerOptions.JsonOptions);

            foreach (var forecast in forecasts)
            {
                yield return forecast;
            }
        }
    }
}
