using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{
    [TestClass]
    public class SalaryTests
    {
        [TestMethod]
        [DataRow (25500.50)]
        [DataRow (21500.83)]
        [DataRow (19340.23)]
        public void Salary_ValidTest(double salary)
        {
            try
            {
                var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                               new DateTime(1997, 11, 16), salary, 2, "0723225639", "Jonts@gmail.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is AssertFailedException);
            }
       
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow(-25500.50)]
        [DataRow(-21500.83)]
        [DataRow(-19340.23)]
        [DataRow(-0.01)]
        public void SalaryTooSmall_InvalidTest(double salary)
        {
           
            var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                               new DateTime(1997, 11, 16), salary, 2, "0723225639", "Jonts@gmail.com");

                  
        }

    }
}
