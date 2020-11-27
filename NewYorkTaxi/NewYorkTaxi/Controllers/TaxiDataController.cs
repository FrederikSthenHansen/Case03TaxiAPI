using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SODA;

namespace NewYorkTaxi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxiDataController : ControllerBase
    {

        SodaClient myClient = new SodaClient("https://data.cityofnewyork.us");

        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        //};

        private readonly ILogger<TaxiDataController> _logger;

        public TaxiDataController(ILogger<TaxiDataController> logger)
        {
            _logger = logger;
        }






        // Get a reference to the resource itself
        // The result (a Resouce object) is a generic type
        // The type parameter represents the underlying rows of the resource
        // and can be any JSON-serializable class
       // var myDataset = myClient.GetResource<Taxidata>("t29m-gskq");

        // Resource objects read their own data
        //var rows = myDataset.GetRows(limit: 5000);

        //Console.WriteLine($"Got {rows.Count()} results. Dumping first results:" ;

        //foreach (var keyValue in rows.First())

        //[HttpGet]
        //public async Task<IActionResult> GetAveragePassengerCountForAllVendor()
        //{
        //    ViewResult ResulsintView=
        //    return new ViewResult();
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

    }
}

