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


        //string SoQL100 = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=vendorid,passenger_count&$limit=100";
        readonly string SoQLVendorsAndPasengerCount = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=vendorid,passenger_count,tip_amount,total_amount,Trip_Distance";
        readonly string SoQLPassengersAndTips = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=passenger_count,tip_amount";
        readonly string SoQLDistinctVendors = "https://data.cityofnewyork.us/resource/t29m-gskq.json?$select=distinct%20vendorid";

        public HomeController(ILogger<HomeController> logger)
        {   
            _logger = logger;
            Display = new AveragePassengerDisplay();
        }

        public IActionResult Index()
        { 
            return View();
        }

        private async Task<bool> writeJsonResponse(string myUrl)
        {
            //clean up jsonfile from previous query
            System.IO.File.Delete(myJsonFilePath);

            // write JSON directly to a file
            System.IO.StreamWriter QueryWriter = new StreamWriter(myJsonFilePath);


            //Create a new instance of HttpClient, and make the HTTP request and write the response to a JSon file
            using (HttpClient client = new HttpClient())
            {
                //Setting up the response...         
                //myUrl = System.Web.HttpUtility.UrlEncode(myUrl);
                using (HttpResponseMessage res = await client.GetAsync(myUrl))
                using (HttpContent content = res.Content)
                {
                    string data = await content.ReadAsStringAsync();
                    if (data != null)
                    {
                        QueryWriter.Write(data);
                        QueryWriter.Close();
                        return true;
                    }
                    else  
                    {
                        QueryWriter.Close();
                        return false; 
                    }
                }
                
            }
            
        }

       
        public async Task<IActionResult> Tips()
        {
            if (await writeJsonResponse(SoQLPassengersAndTips)== true)
            {
                //open Jsonfile and deserialize content
                if (System.IO.File.Exists(myJsonFilePath))
                {
                    using (StreamReader reader = new StreamReader(myJsonFilePath))
                    {
                        string json = reader.ReadToEnd();

                        reader.Close();

                        //Remember to Always mirror the Database property names in your c# object properies!!!
                        items = JsonConvert.DeserializeObject<List<AvgPassenger>>(json);
                    }
                }

                //Deliver items to DisplayModel
                Display.AvgPassengers = items;

                //Seperate the vendors in the displaymodel
                Display.SortDistinctVendors();
            }

                return View(Display);
        }
     
        public async Task<IActionResult> Privacy()
        {  
           // send Query about how many Vendors there are and write response to Jsonfile
            //if (await writeJsonResponse(SoQLDistinctVendors) == true)
            //{
            //    if (System.IO.File.Exists(myJsonFilePath))
            //    {
            //        using (StreamReader reader = new StreamReader(myJsonFilePath))
            //        {
            //            string json = reader.ReadToEnd();

            //            reader.Close();

            //            //Remember to Always mirror the Database property names in your c# object properies!!!
            //            Display.VendorIdLabel = JsonConvert.DeserializeObject<List<int>>(json);
            //        }
            //    }
            //}

            //send Query about vendors and passengercounts and write response to Jsonfile
            if (await writeJsonResponse(SoQLVendorsAndPasengerCount) == true)
                {
                    //open Jsonfile and deserialize content
                    if (System.IO.File.Exists(myJsonFilePath))
                    {
                        using (StreamReader reader = new StreamReader(myJsonFilePath))
                        {
                            string json = reader.ReadToEnd();

                            reader.Close();

                            //Remember to Always mirror the Database property names in your c# object properies!!!
                            items = JsonConvert.DeserializeObject<List<AvgPassenger>>(json);
                        }
                    }

                    //Deliver items to DisplayModel
                    Display.AvgPassengers = items;

                //Seperate the vendors in the displaymodel
                Display.SortDistinctVendors();
            }
            
            return View(Display);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
