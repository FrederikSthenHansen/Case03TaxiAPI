using System;
using System.ComponentModel.DataAnnotations;

namespace NewYorkTaxi
{
    /// <summary>
    /// Class to store Any kind of Taxi data.
    /// </summary>
    public class RawData
    {
        [Display(Name = "Vendor ID Number")]
        public int VendorID { get; set; }

        public int Passenger_Count { get; set; }

        public double Total_Amount { get; set; }

        public double Trip_Distance { get; set; }

        public double Tip_Amount { get; set; }

        public RawData()
        {

        }
        
    }
}
