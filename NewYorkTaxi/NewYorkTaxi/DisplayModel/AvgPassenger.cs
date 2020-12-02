using System;

namespace NewYorkTaxi
{
    /// <summary>
    /// Class to hold a vendor iD and an int for Passenger count. name is misleading. 
    /// </summary>
    public class AvgPassenger
    {
        public int VendorID { get; set; }

        public int PassengerCountAverage { get; set; }

        public AvgPassenger()
        {

        }
        public AvgPassenger(String mock)
        {
            if (mock == "mock")
            {
                Random rng = new Random();
                VendorID = rng.Next(1, 3);
                PassengerCountAverage = rng.Next(0, 6);
            }
        }
    }
}
