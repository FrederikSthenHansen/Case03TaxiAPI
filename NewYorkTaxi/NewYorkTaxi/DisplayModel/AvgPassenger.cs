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

        public double Total_Amount { get; set; }

        public double Trip_Distance { get; set; }

        public double Tip_Amount { get; set; }

        public AvgPassenger()
        {

        }
        
    }
}
