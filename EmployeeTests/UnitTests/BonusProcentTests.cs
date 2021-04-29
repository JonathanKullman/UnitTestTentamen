using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{
    [TestClass]
    public class BonusProcentTests
    {
        [TestMethod]
        [DataRow (9, 1292)]
        [DataRow (57, 8183)]
        [DataRow (99, 14212)]
        public void BonusProcent_ValidTest(double bonusProcent, int expected)
        {
           var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                          new DateTime(1997, 11, 16), 14356, bonusProcent, "0723225639", "Jonts@gmail.com");

            var actual = employee.BonusProcent;

            Assert.AreEqual(expected, actual);
               
        }

        [TestMethod]
        [DataRow(10, 1001)]
        [DataRow(50, 4999)]
        [DataRow(20, 2002)]
        public void BonusProcent_InvalidTest(double bonusProcent, int expected)
        {
            var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                           new DateTime(1997, 11, 16), 10000, bonusProcent, "0723225639", "Jonts@gmail.com");

            var actual = employee.BonusProcent;

            Assert.AreNotEqual(expected, actual);

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(101)]
        [DataRow(100.1)]
        [DataRow(120)]
        [DataRow(-0.01)]
        [DataRow(-0.1)]
        [DataRow(-30)]
        public void BonusProcentAboveHundredOrBelowZero_InvalidTest(double bonusProcent)
        {
            var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                           new DateTime(1997, 11, 16), 10000, bonusProcent, "0723225639", "Jonts@gmail.com");


        }



    }
        
   
}
