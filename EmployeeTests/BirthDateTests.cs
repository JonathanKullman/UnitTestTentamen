using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{
    [TestClass]
    public class BirthDateTests
    {
        [TestMethod]
        [DataRow(2021, 04, 24)]
        [DataRow(1976, 8, 14)]
        [DataRow(1999, 11, 4)]
        [DataRow(1945, 10, 4)]
        public void BirthDate_ValidTest(int year, int month, int day)
        {
            try
            {
                var employee = new Employee("TestName", "LastTestName", new DateTime(2015, 11, 03),
                     new DateTime(year, month, day), 34000, 2, "0723225639", "Jonts@gmail.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(2033, 10, 14)]
        [DataRow(2025, 08, 25)]
        [DataRow(2021, 06, 21)]
        public void BirthDateFuture_InvalidTest(int year, int month, int day)
        {

            var employee = new Employee("TestName", "LastTestName", new DateTime(2015, 11, 03),
                     new DateTime(year, month, day), 34000, 2, "0723225639", "Jonts@gmail.com");

        }

    }
}
