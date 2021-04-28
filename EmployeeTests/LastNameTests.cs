using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{
    [TestClass]
    public class LastNameTests

    {
        [TestMethod]
        [DataRow("Kullman")]
        [DataRow("Johansson")]
        [DataRow("Einarsson")]
        public void LastName_ValidTest(string lastName)
        {
            try
            {
                var employee = new Employee("Testname", lastName, new DateTime(2005, 10, 13),
                               new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is AssertFailedException);
            }


        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        [DataRow("")]
        public void LastNameEmpty_InvalidTest(string lastName)
        {

            var employee = new Employee("TestName", lastName, new DateTime(2005, 10, 13),
                            new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");


        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow("LongLastnameMeantToFail")]
        public void LastNameTooLong_InvalidTest(string lastName)
        {
            var employee = new Employee("TestName", lastName, new DateTime(2005, 10, 13),
                        new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");

        }

    }
}
