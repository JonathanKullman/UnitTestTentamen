using EmployeeInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        [DataRow("jonte.kull@gmail.com")]
        [DataRow("jontekull@gmail.com")]
        [DataRow(" jontekull@gmail.com")] // .Trim() gör det möjligt att sätta " " framför och i slutet.
        [DataRow(" jontekull@gmail.com ")] // .Trim() gör det möjligt att sätta " " framför och i slutet.
        public void PhoneNr_ValidTest(string email)
        {
            try
            {
                var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                               new DateTime(1997, 11, 16), 15000, 2, "072 - 3225639", email);

                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is AssertFailedException);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("jontekull @gmail.com")]
        [DataRow("jontekull@@gmail.com")]
        [DataRow("jontekull@@gmail .com")]
        public void EmailMoreThanOneATSignOrWhitespace_InvalidTest(string email)
        {
            var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                              new DateTime(1997, 11, 16), 15000, 2, "072 - 3225639", email);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("jontekull@gmailcom")]
        [DataRow("jontekullgmail.com")]
        public void EmailWithNoDotOrNoATSign_InvalidTest(string email)
        {
            var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                              new DateTime(1997, 11, 16), 15000, 2, "072 - 3225639", email);

        }


    }
}
