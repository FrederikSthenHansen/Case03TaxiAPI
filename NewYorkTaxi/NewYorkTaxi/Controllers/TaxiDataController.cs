using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using SODA;
using System.Net.Http;

namespace NewYorkTaxi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaxiDataController : ControllerBase
    {

        //SodaClient myClient = new SodaClient("https://data.cityofnewyork.us");

      
        private readonly ILogger<TaxiDataController> _logger;

        public TaxiDataController(ILogger<TaxiDataController> logger)
        {
            _logger = logger;
        }

        readonly string myJsonFilePath = @"C:\Users\SA02- Frederik\Documents\Case03TaxiAPI\Case03TaxiAPI\NewYorkTaxi\NewYorkTaxi\Files\QueryResult.Json";

        [HttpGet]
        [Route("[controller]/Avg_Passenger_Count")]
        public async Task<IActionResult> GetAveragePassengerCountForAllVendor()
        {
            string SoQL = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=vendorid,passenger_count"; 

            // write JSON directly to a file
            System.IO.StreamWriter QueryWriter = new StreamWriter(myJsonFilePath);

            //Create a new instance of HttpClient
            using (HttpClient client = new HttpClient()) 
            {
                //Setting up the response...         

                using (HttpResponseMessage res = await client.GetAsync(SoQL))
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                         QueryWriter.Write(data);
                    }
                }
            }

            //open and deserialize result
           
                using (StreamReader r = new StreamReader(myJsonFilePath))
                {
                    string json = r.ReadToEnd();
                    List<AvgPassenger> items = JsonConvert.DeserializeObject<List<AvgPassenger>>(json);
                }

            return new ViewResult();
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

