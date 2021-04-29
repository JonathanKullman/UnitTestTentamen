using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{
    [TestClass]
    public class HireDateTests
    {
        [TestMethod]
        [DataRow (2002, 7, 24)]
        [DataRow (1976, 8, 14)]
        [DataRow (1988, 11, 4)]
        [DataRow (1999, 11, 4)]
        [DataRow (1951, 10, 4)]
        public void HireDate_ValidTest(int year, int month, int day)
        {
            try
            {
                var employee = new Employee("TestName", "LastTestName", new DateTime(year, month, day),
                     new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(1951, 03, 4)]
        [DataRow(1950, 08, 25)]
        [DataRow(1855, 02, 13)]
        public void HireDateTooEarly_InvalidTest(int year, int month, int day)
        {
            
            var employee = new Employee("TestName", "LastTestName", new DateTime(year, month, day),
                     new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(2033, 10, 14)]
        [DataRow(2025, 08, 25)]
        [DataRow(2021, 06, 21)]
        public void HireDateFuture_InvalidTest(int year, int month, int day)
        {

            var employee = new Employee("TestName", "LastTestName", new DateTime(year, month, day),
                     new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");

        }

    }
   
}
