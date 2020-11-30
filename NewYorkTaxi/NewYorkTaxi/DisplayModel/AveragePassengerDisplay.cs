using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTaxi.DisplayModel
{
    public class AveragePassengerDisplay
    {
        public List<AvgPassenger> AvgPassengers;
        //public List<AvgPassenger>[] DistinctVendors;
        public AvgPassenger Label;

        public AveragePassengerDisplay()
        {
            Label = new AvgPassenger();
        }

        
    }
}
