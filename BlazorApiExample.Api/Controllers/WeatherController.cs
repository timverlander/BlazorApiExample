using BlazorApiExample.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlazorApiExample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private IList<WeatherType> _weatherTypes = new[]
        {
            new WeatherType("Freezing", -22, 2),
            new WeatherType("Warm", 6, 12),
            new WeatherType("Scorching", 16, 25)
        };

        private readonly Random _rng = new();

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
            => Enumerable
                .Range(1, 5)
                .Select(_ => _weatherTypes.MysteryMethod(_rng))
                .Select((weatherType, index) => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = _rng.Next(weatherType.MinTempC, weatherType.MaxTempC),
                    Summary = weatherType.Name
                });
    }

    public static class IListExtensions
    {
        public static TEntry MysteryMethod<TEntry>(this IList<TEntry> list, Random rng)
            => list?.Any() ?? false
                ? list[rng.Next(list.Count)]
                : throw new Exception("The list is empty");
    }
}