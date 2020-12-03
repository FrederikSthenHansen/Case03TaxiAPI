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
using Newtonsoft.Json.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
       
        private readonly ILogger<HomeController> _logger;
        private AveragePassengerDisplay Display;
        public static List<NewYorkTaxi.AvgPassenger> items;
        //Husk at lave en et par ekstra kodelinjer til at have en ny hardcoded filepath til Json filen, hvis jeg koder hjemmefra
        readonly string myJsonFilePath = @"C:\Users\SA02- Frederik\Documents\Case03TaxiAPI\Case03TaxiAPI\NewYorkTaxi\NewYorkTaxi\Files\QueryResult.Json";

        JsonSerializerSettings mySettings = new JsonSerializerSettings();
        public HomeController(/*MvcDbContext context*/ILogger<HomeController> logger)
        {_logger = logger;
            //_context = context;
            Display = new AveragePassengerDisplay();
            

        }

       

        public IActionResult Index()
        {
            
            return View();
        }


        private async Task<bool> writeJsonResponse(string myUrl)
        {

            // write JSON directly to a file
            System.IO.StreamWriter QueryWriter = new StreamWriter(myJsonFilePath);


            //Create a new instance of HttpClient, and make the HTTP request and write the response to a JSon file
            using (HttpClient client = new HttpClient())
            {
                //Setting up the response...         

                using (HttpResponseMessage res = await client.GetAsync(myUrl))
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        QueryWriter.Write(data);
                    }
                }
            }
            QueryWriter.Close();
            return true;
        }

        public async Task<IActionResult> Privacy()
        {
            //clean up jsonfile from previous query
            System.IO.File.Delete(myJsonFilePath);

            string SoQL100 = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=vendorid,passenger_count&$limit=100";
            string SoQL = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=vendorid,passenger_count";

            //send Query and write response to Jsonfile


            if (await writeJsonResponse(SoQL)== true)
            {
                JObject obj = null;
                JsonSerializer jsonSerializer = new JsonSerializer();
                //open Jsonfile and deserialize content

                if (System.IO.File.Exists(myJsonFilePath))
                {
                    

                    using (StreamReader reader = new StreamReader(myJsonFilePath))
                    {
                       string json= reader.ReadToEnd();
                       
                        reader.Close();

                        //Remember to Always mirror the Database property names in your c# object properies!!!
                        items = JsonConvert.DeserializeObject<List<AvgPassenger>>(json);

                      
                    }
                }

                //placeholder til frontend
                //items.Clear();
                //for (int x = 0; x < 40; x++)
                //{
                //    items.Add(new AvgPassenger("mock"));
                //}
                //ende på placeholder


  
               //Deliver items to DisplayModel
                Display.AvgPassengers = items;

                //Seperate the vendors in the displaymodel
                Display.SortDistinctVendors();
            }
            //Mangler at finde en måde at få mit view frem som resultat af Requested
            return View(Display);
        }

        private List<AvgPassenger> ReadAvgPassenger(StreamReader readerParam)
        {
            List<AvgPassenger> ret=new List<AvgPassenger>();
            AvgPassenger obj= new AvgPassenger();
            obj.VendorID = readerParam.Read(); //find a way to read each property.


            ret.Add(obj);
            return ret;
        }

        //public void readJson()
        //{
        //    myReader.SetToken(myJsonFilePath)
        //    myReader.Read();


        //}
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
