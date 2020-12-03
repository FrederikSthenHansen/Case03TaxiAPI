using System;

namespace NewYorkTaxi
{
    /// <summary>
    /// Class to store Any kind of Taxi data. Name is misleading 
    /// </summary>
    public class AvgPassenger
    {
        public int VendorID { get; set; }

        public int Passenger_Count { get; set; }

        public decimal Total_Amount { get; set; }

        public decimal Trip_Distance { get; set; }

        public decimal Tip_Amount { get; set; }

        public AvgPassenger()
        {

        }
        
    }
}
