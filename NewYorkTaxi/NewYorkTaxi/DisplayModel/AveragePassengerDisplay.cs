using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTaxi.DisplayModel
{
    public class AveragePassengerDisplay
    {
        public List<AvgPassenger> AvgPassengers;
        //public List<int>[] DistinctVendors;
        public List<DistincVendorPassengerCount> DistinctVendors;
        public AvgPassenger Label;
        public int VendorIdLabel { get { return iterator + 1; } }
        public string displaydata;
       public int iterator;
        int vendorCount = 2; //get vendors from Database somehow.




        public int SortDistinctVendors(int vendors)
        {
            vendorCount = vendors;
            DistinctVendors = new List<DistincVendorPassengerCount>();

            for (int v = 0; v< vendorCount; v++)
            {
              DistincVendorPassengerCount Dvp=  new DistincVendorPassengerCount(v+1);
                DistinctVendors.Add(Dvp);

                for (int a = 0; a < AvgPassengers.Count; a++)
                {
                    if (AvgPassengers[a].VendorID == v+1)
                    {
                        Dvp.passengerCounts.Add(AvgPassengers[a].Passenger_Count);
                    }
                }
            }
            
            
            //DistinctVendors = new List<int>[vendorCount];
            //for (int x=0; x < vendorCount; x++)
            //{

            //    DistinctVendors[x] = new List<int>();
            //    for (int a = 0; a < AvgPassengers.Count; a++)
            //    {
            //        if (AvgPassengers[a].VendorID == x+1)
            //        {
            //            DistinctVendors[x].Add(AvgPassengers[a].PassengerCount);
            //        }
            //    }
            //}



            return 1;
        }

        


        public int NumberReset( int number)
        {
           return number = 0;
            
        }
        public int Iterate()
        {
         
            iterator++;
            return iterator;
        }

        public AveragePassengerDisplay()
        {
            Label = new AvgPassenger();
        }

        
    }
}
