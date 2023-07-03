using gRPC.Server.Protos;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace gRPC.Client.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        private MeterReadingService.MeterReadingServiceClient _meterReadingServiceClient;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            var channel = GrpcChannel.ForAddress("https://localhost:7096");
            _meterReadingServiceClient = new MeterReadingService.MeterReadingServiceClient(channel);
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {            
            var res = _meterReadingServiceClient.AddReading(new ReadingMessage() { CustId = 1, Reading = 100 });
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}