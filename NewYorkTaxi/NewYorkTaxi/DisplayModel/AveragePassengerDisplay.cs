using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTaxi.DisplayModel
{
    public class AveragePassengerDisplay
    {
        public List<AvgPassenger> AvgPassengers;
        public List<int>[] DistinctVendors;
        public AvgPassenger Label;
        public int VendorIdLabel;
        public string displaydata;
       public int iterator;
        

       


        public int SortDistinctVendors()
        {
            int vendorCount = 2;
            DistinctVendors = new List<int>[vendorCount];
            for (int x=0; x < vendorCount; x++)
            {
                
                DistinctVendors[x] = new List<int>();
                for (int a = 0; a < AvgPassengers.Count; a++)
                {
                    if (AvgPassengers[a].VendorID == x+1)
                    {
                        DistinctVendors[x][a]= AvgPassengers[a].PassengerCountAverage;
                    }
                }
            }



            return 1;
        }

        


        public int NumberReset( int number)
        {
           return number = 0;
            
        }
        public int Iterate(int number)
        {
         
            number++;
            return number;
        }

        public AveragePassengerDisplay()
        {
            Label = new AvgPassenger();
        }

        
    }
}
