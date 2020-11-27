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
        public async Task<IActionResult> GetAveragePassengerCountForAllVendors()
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


            //Mangler at finde en måde at få mit view frem som resultat af Requested
            return new ViewResult();
        }

    }
}

