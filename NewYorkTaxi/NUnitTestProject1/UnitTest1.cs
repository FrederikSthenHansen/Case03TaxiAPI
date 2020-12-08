using NUnit.Framework;
using NewYorkTaxi.DisplayModel;
using System.Collections.Generic;
using NewYorkTaxi;

namespace NUnitTestProject1
{
    public class Tests
    {
        RawData testData1=new RawData();
        RawData testData2 = new RawData();
        RawData testData3 = new RawData();

        TaxiDataDisplay Display = new TaxiDataDisplay();

        public static List<NewYorkTaxi.RawData> items;
        [SetUp]
        public void Setup()
        {
        }
    


        [Test]
        public void SortDistinctVendorsFillsDistinctVendors()
        {
            #region arrange
            //arrange
            Display.MyDatalist = new List<RawData>();

            testData1.VendorID = 1;
            testData1.Passenger_Count = 1;
            testData1.Tip_Amount = 1;
            testData1.Total_Amount = 1;
            testData1.Trip_Distance = 1;

            testData2.VendorID = 2;
            testData2.Passenger_Count = 1;
            testData2.Tip_Amount = 1;
            testData2.Total_Amount = 1;
            testData2.Trip_Distance = 1;

            testData3.VendorID = 4;
            testData3.Passenger_Count = 1;
            testData3.Tip_Amount = 1;
            testData3.Total_Amount = 1;
            testData3.Trip_Distance = 1;

            Display.MyDatalist.Add(testData1);
            Display.MyDatalist.Add(testData2);
            Display.MyDatalist.Add(testData3);
            #endregion

            //act
            Display.SortDistinctVendors();

            Assert.AreEqual(3, Display.DistinctVendors.Count);
        }

        [Test]
        public void SortDistinctVendorsDeletesfromMyDataList()
        {
            #region arrange
            //arrange
            Display.MyDatalist = new List<RawData>();

            testData1.VendorID = 1;
            testData1.Passenger_Count = 1;
            testData1.Tip_Amount = 1;
            testData1.Total_Amount = 1;
            testData1.Trip_Distance = 1;

            testData2.VendorID = 2;
            testData2.Passenger_Count = 1;
            testData2.Tip_Amount = 1;
            testData2.Total_Amount = 1;
            testData2.Trip_Distance = 1;

            testData3.VendorID = 4;
            testData3.Passenger_Count = 1;
            testData3.Tip_Amount = 1;
            testData3.Total_Amount = 1;
            testData3.Trip_Distance = 1;

            Display.MyDatalist.Add(testData1);
            Display.MyDatalist.Add(testData2);
            Display.MyDatalist.Add(testData3);
            #endregion

            //act
            Display.SortDistinctVendors();



            Assert.AreEqual(0, Display.MyDatalist.Count);
        }
    }
}