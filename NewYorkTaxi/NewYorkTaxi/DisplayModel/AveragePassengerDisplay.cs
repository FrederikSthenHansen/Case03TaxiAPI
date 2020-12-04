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
        public List<int> VendorIdLabel = new List<int>();
        public string displaydata;
       public int iterator;
       public int vendorCount { get { return VendorIdLabel.Count; }}




        public int SortDistinctVendors()
        {

            //Mock Vendor ID count code start
            VendorIdLabel.Add(1);
            VendorIdLabel.Add(2);
            //VendorIdLabel.Add(4);
            //Mock vendor iD count Code ends
            
            
            DistinctVendors = new List<DistincVendorPassengerCount>();

            for (int v = 0; v< vendorCount; v++)
            {
              DistincVendorPassengerCount Dvp=  new DistincVendorPassengerCount(VendorIdLabel[v]);
                DistinctVendors.Add(Dvp);

                for (int a = 0; a < AvgPassengers.Count; a++)
                {
                    if (AvgPassengers[a].VendorID == VendorIdLabel[v])
                    {
                        Dvp.passengerCounts.Add(AvgPassengers[a].Passenger_Count);
                        AvgPassengers.RemoveAt(a);
                    }
                }
            }
            
          
            return 1;
        }

        


        public int NumberReset( )
        {
           return iterator = 0;
            
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
