namespace BlazorApiExample.Models
{
    public class WeatherType
    {
        public string Name { get; set; }
        public int MinTempC { get; set; }
        public int MaxTempC { get; set; }

        public WeatherType()
        { }

        public WeatherType(string name, int minTempC, int maxTempC)
            => (Name, MinTempC, MaxTempC) = (name, minTempC, maxTempC);
    }
}
