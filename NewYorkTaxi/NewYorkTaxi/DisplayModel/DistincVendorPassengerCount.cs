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
        public List<double> Tips;
        public List<double> TotalPrices;
        public List<double> Distances;

        public int TotalTipsDisplay 
        { get 
            { var input = Math.Round(TotalTips, 0);

                int ret = Convert.ToInt32(input);
                    return ret;
            } 
        }

        public int TotalFaresDisplay
        {
            get
            {
                var input = Math.Round(TotalFares, 0);

                int ret = Convert.ToInt32(input);
                return ret;
            }
        }

        [Display(Name ="Total Amount Earned though Fares:")]
        public double TotalFares
        {
            get
            {
                double ret;
                if (TotalPrices == null)
                { ret = 0; }
                else
                {
                    ret = TotalPrices.Sum();
                    ret = Math.Round(ret, 2);
                }
                return ret;
            }
        }

        [Display(Name ="Total Tips Earned:")]
        public double TotalTips { 
            get
            {
                double ret;
                if (Tips == null)
                { ret = 0; }
                else { ret = Tips.Sum();
                        ret = Math.Round(ret, 2);
                }
                return ret;
            }
        }

        [Display(Name ="Total trips Driven:")]
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

        [Display(Name = "Passenger Count Average:")]
        public double averageValue 
       {
            get 
            {
                double ret;
                if (passengerCounts == null)
                { ret = 0; }
                else {
                    ret = passengerCounts.Average();
                        ret = Math.Round(ret, 2);  }

                return ret;

                ////placeholder code starts
                //return 2.45;
                //Placeholder code ends
            }
        }

        [Display(Name = "Total Passengers for Vendor:")]
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
            VendorName = $"Vendor Number {vendorIdNumber}:";
            passengerCounts = new List<int>();
            Tips = new List<double>();
            TotalPrices = new List<double>();
            Distances = new List<double>();
        }
    }
}
