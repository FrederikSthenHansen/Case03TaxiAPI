using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using NewYorkTaxi.DisplayModel;

namespace NewYorkTaxi.Controllers
{
    public class AvgPassengerController : Controller
    {
        //Husk at lave en et par ekstra kodelinjer til at have en ny hardcoded filepath til Json filen, hvis jeg koder hjemmefra
        readonly string myJsonFilePath = @"C:\Users\SA02- Frederik\Documents\Case03TaxiAPI\Case03TaxiAPI\NewYorkTaxi\NewYorkTaxi\Files\QueryResult.Json";
        //private readonly MvcDbContext _context;
        private AveragePassengerDisplay Display;
        public static List<AvgPassenger> items;

        public AvgPassengerController(/*MvcDbContext context*/)
        {
            Display = new AveragePassengerDisplay();
        }


        [HttpGet]
        [Route("[controller]")]
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
            using (StreamReader reader = new StreamReader(myJsonFilePath))
            {
                string json = reader.ReadToEnd();

                //denne Deserializering skal sikkert finjusteres.
                items = JsonConvert.DeserializeObject<List<AvgPassenger>>(json);

            }

            items.GroupBy(x => x.VendorID);

            Display.AvgPassengers = items;
            //Mangler at finde en måde at få mit view frem som resultat af Requested
            return View (Display);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
