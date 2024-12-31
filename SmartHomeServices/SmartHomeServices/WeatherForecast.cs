using System.ComponentModel;

namespace SmartHomeServices
{
    public class WeatherForecast
    {
        [property: Description("创建日期")]
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
