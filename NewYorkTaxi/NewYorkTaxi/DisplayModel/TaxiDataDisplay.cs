using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewYorkTaxi.DisplayModel
{
    public class TaxiDataDisplay
    {/// <summary>
    /// List of raw data objects deserialized from the Jsonfile.
        public List<RawData> MyDatalist;
        /// <summary>
        /// List to contain the data Desirialized from Json
        /// </summary>
        public List<DisplayValueData> DistinctVendors;

        public RawData Label;

        public List<int> VendorIdLabel = new List<int>();

        public string displaydata;

       //public int iterator;
       public int vendorCount { get { return VendorIdLabel.Count; }}




        public int SortDistinctVendors()
        {

            //Mock Vendor ID count code start
            VendorIdLabel.Add(1);
            VendorIdLabel.Add(2);
            VendorIdLabel.Add(4);
            //Mock vendor iD count Code ends
            
            
            DistinctVendors = new List<DisplayValueData>();

            for (int v = 0; v< vendorCount; v++)
            {
              DisplayValueData Dvp=  new DisplayValueData(VendorIdLabel[v]);
                DistinctVendors.Add(Dvp);

                for (int a = 0; a < MyDatalist.Count; a++)
                {
                        if (MyDatalist[a].VendorID == VendorIdLabel[v])
                        {
                            Dvp.passengerCounts.Add(MyDatalist[a].Passenger_Count);
                            Dvp.Tips.Add(MyDatalist[a].Tip_Amount);
                            Dvp.TotalPrices.Add(MyDatalist[a].Total_Amount);
                            Dvp.Distances.Add(MyDatalist[a].Trip_Distance);
                            MyDatalist.RemoveAt(a);
                        }
                }
            }
            
          
            return 1;
        }

        


        //public int NumberReset( )
        //{
        //   return iterator = 0;
            
        //}
        //public int Iterate()
        //{
         
        //    iterator++;
        //    return iterator;
        //}

        public TaxiDataDisplay()
        {
            Label = new RawData();
        }

        
    }
}
