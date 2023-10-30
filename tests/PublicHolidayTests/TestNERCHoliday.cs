using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PublicHoliday;

namespace PublicHolidayTests
{

    /// <summary>
    /// Using official calendar from http://www.opm.gov/fedhol/2006.asp
    /// </summary>
    [TestClass]
    public class TestNERCHoliday
    {
        [TestMethod]
        public void TestThanksgiving2018()
        {
            var expected = new DateTime(2018, 11, 22);
            var actual = NERCHoliday.Thanksgiving(2018);
            Assert.AreEqual(expected, actual);
        }

         [TestMethod]
        public void TestNewYear2004()
        {
            var expected = new DateTime(2004, 1, 1);
            var actual = NERCHoliday.NewYear(2004);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMemorial2004()
        {
            var expected = new DateTime(2004, 5, 31);
            var actual = NERCHoliday.MemorialDay(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence2004()
        {
            var expected = new DateTime(2004, 7, 5);
            var actual = NERCHoliday.IndependenceDay(2004);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestLabor2004()
        {
            var expected = new DateTime(2004, 9, 6);
            var actual = NERCHoliday.LaborDay(2004);
            Assert.AreEqual(expected, actual);
        }

          [TestMethod]
        public void TestThanksgiving2004()
        {
            var expected = new DateTime(2004, 11, 25);
            var actual = NERCHoliday.Thanksgiving(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2004()
        {
            var expected = new DateTime(2004, 12, 25);
            var actual = NERCHoliday.Christmas(2004);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestNewYear()
        {
            var expected = new DateTime(2006, 1, 2);
            var actual = NERCHoliday.NewYear(2006);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMemorial()
        {
            var expected = new DateTime(2006, 5, 29);
            var actual = NERCHoliday.MemorialDay(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIndependence()
        {
            var expected = new DateTime(2006, 7, 4);
            var actual = NERCHoliday.IndependenceDay(2006);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestThanksgiving()
        {
            var expected = new DateTime(2006, 11, 23);
            var actual = NERCHoliday.Thanksgiving(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas()
        {
            var expected = new DateTime(2006, 12, 25);
            var actual = NERCHoliday.Christmas(2006);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestThanksgiving1999()
        {
            var expected = new DateTime(1999, 11, 25);
            var actual = NERCHoliday.Thanksgiving(1999);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestIsPublicHoliday()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new NERCHoliday().IsPublicHoliday(thanksgiving);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestNextWorkingDay()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new NERCHoliday().NextWorkingDay(thanksgiving);
            Assert.AreEqual(new DateTime(1999, 11, 26), result);
        }

     
        [TestMethod]
        public void TestPublicHolidays()
        {
            var thanksgiving = new DateTime(1999, 11, 25);
            var result = new NERCHoliday().PublicHolidays(1999);
            Assert.AreEqual(6, result.Count);
            Assert.IsTrue(result.Contains(thanksgiving));
        }

        [TestMethod]
        public void TestPublicHolidayInformation()
        {
            var nercHoliday = new NERCHoliday();
            var hols = nercHoliday.PublicHolidays(2017);
            var infos = nercHoliday.PublicHolidaysInformation(2017);
            Assert.AreEqual(hols.Count, infos.Count);
            foreach (var info in infos)
            {
                Assert.IsTrue(hols.Contains(info), "observed date is implicitly in both lists");
            }
        }

        #region 2022 Tests

        [TestMethod]
        public void TestNewYears2022()
        {
            var expected = new DateTime(2022, 1, 1);
            var actual = NERCHoliday.NewYear(2022);
            Assert.AreEqual(expected, actual);
        }

 
        [TestMethod]
        public void TestMemorialDay2022()
        {
            var expected = new DateTime(2022, 5, 30);
            var actual = NERCHoliday.MemorialDay(2022);
            Assert.AreEqual(expected, actual);
        }

        

        [TestMethod]
        public void TestIndependenceDay2022()
        {
            var expected = new DateTime(2022, 7, 4);
            var actual = NERCHoliday.IndependenceDay(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLaborDay2022()
        {
            var expected = new DateTime(2022, 9, 5);
            var actual = NERCHoliday.LaborDay(2022);
            Assert.AreEqual(expected, actual);
        }

 
 
        [TestMethod]
        public void TestThanksgiving2022()
        {
            var expected = new DateTime(2022, 11, 24);
            var actual = NERCHoliday.Thanksgiving(2022);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2022()
        {
            var expected = new DateTime(2022, 12, 26);
            var actual = NERCHoliday.Christmas(2022);
            Assert.AreEqual(expected, actual);
        }
        #endregion

        #region 2023 Tests

        [TestMethod]
        public void TestNewYears2023()
        {
            var expected = new DateTime(2023, 1, 2);
            var actual = NERCHoliday.NewYear(2023);
            Assert.AreEqual(expected, actual);
        }

 
 

        [TestMethod]
        public void TestMemorialDay2023()
        {
            var expected = new DateTime(2023, 5, 29);
            var actual = NERCHoliday.MemorialDay(2023);
            Assert.AreEqual(expected, actual);
        }

 

        [TestMethod]
        public void TestIndependenceDay2023()
        {
            var expected = new DateTime(2023, 7, 4);
            var actual = NERCHoliday.IndependenceDay(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLaborDay2023()
        {
            var expected = new DateTime(2023, 9, 4);
            var actual = NERCHoliday.LaborDay(2023);
            Assert.AreEqual(expected, actual);
        }

  

        [TestMethod]
        public void TestThanksgiving2023()
        {
            var expected = new DateTime(2023, 11, 23);
            var actual = NERCHoliday.Thanksgiving(2023);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestChristmas2023()
        {
            var expected = new DateTime(2023, 12, 25);
            var actual = NERCHoliday.Christmas(2023);
            Assert.AreEqual(expected, actual);
        }
        #endregion
    }
}
