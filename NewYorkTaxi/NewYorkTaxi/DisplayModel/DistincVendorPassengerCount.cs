using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTaxi.DisplayModel
{
    public class DistincVendorPassengerCount
    {public string VendorName;
       public List<int> passengerCounts;

        [Display(Name ="Total trips Driven")]
        public int TotalTrips {
            get
            {
                int ret;
                if (passengerCounts == null)
                { ret = 0; }
                else { ret = passengerCounts.Count; }
                return ret;
            }
        }

        [Display(Name = "Passenger count average")]
        public double averageValue 
       {
            get 
            {
                double ret;
                if (passengerCounts == null)
                { ret = 0; }
                else { ret = passengerCounts.Average(); }

                return ret;

                ////placeholder code starts
                //return 2.45;
                //Placeholder code ends
            }
        }

        [Display(Name = "Total Passengers for vendor")]
        public int PassengerTotal
        {
            get
            {
                int ret;
                if (passengerCounts == null)
                { ret = 0; }
                else { ret = passengerCounts.Sum(); }
                return ret;
            }
        }
        

        public DistincVendorPassengerCount(int vendorIdNumber)
        {
            VendorName = $"Vendor number {vendorIdNumber}";
            passengerCounts = new List<int>();
        }
    }
}
