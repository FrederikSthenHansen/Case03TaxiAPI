using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Models;
using NewYorkTaxi.DisplayModel;
using System.IO;
using Newtonsoft.Json;
using NewYorkTaxi;
using System.Net.Http;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AveragePassengerDisplay Display;
        public static List<NewYorkTaxi.AvgPassenger> items;
        //Husk at lave en et par ekstra kodelinjer til at have en ny hardcoded filepath til Json filen, hvis jeg koder hjemmefra
        readonly string myJsonFilePath = @"C:\Users\SA02- Frederik\Documents\Case03TaxiAPI\Case03TaxiAPI\NewYorkTaxi\NewYorkTaxi\Files\QueryResult.Json";

        public HomeController(/*MvcDbContext context*/ILogger<HomeController> logger)
        {_logger = logger;
            //_context = context;
            Display = new AveragePassengerDisplay();

        }

       

        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Privacy()
        {
            myJsonFilePath
            string SoQL = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=vendorid,passenger_count";

            // write JSON directly to a file
            System.IO.StreamWriter QueryWriter = new StreamWriter(myJsonFilePath);

            //TODO: Clear JSonfile at the beginning of content.
            

            //Create a new instance of HttpClient, and make the HTTP request and write the response to a JSon file

            //Start of section needed to be cut out and placed in seperate method
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

            //End of section needed to be cut out and placed in seperat Method


            //open and deserialize result
            using (StreamReader reader = new StreamReader(myJsonFilePath))
            {
                string json = reader.ReadToEnd();

                //denne Deserializering skal sikkert finjusteres.
                items = JsonConvert.DeserializeObject<List<AvgPassenger>>(json);

            }

            //Seperate the vendors
            //items.GroupBy(x => x.VendorID);

            Display.AvgPassengers = items;
            //Mangler at finde en måde at få mit view frem som resultat af Requested
            return View(Display);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
