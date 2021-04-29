using EmployeeInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace EmployeeTests
{
    [TestClass]
    public class PhoneNrTests
    {
        [TestMethod]
        [DataRow("072 - 3225639")]
        [DataRow("0723225639")]
        [DataRow("072-3225639")]
        [DataRow("072 3225639")]

        public void PhoneNr_ValidTest(string phoneNr)
        {
            try
            {
                var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                               new DateTime(1997, 11, 16), 15000, 2, phoneNr, "Jonts@gmail.com");

                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is AssertFailedException);
            }


        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        [DataRow("072AbC")]
        [DataRow("070%#&$")]
        [DataRow("@£$€{[]_+´'*^")]
        [DataRow("0723245639 Z")]
        [DataRow("GranaterITrädet")]
        [DataRow("072 + 3225639")]
        [DataRow("072 # 5555555")]
        [DataRow("072-5555555Y")]
        public void PhoneNrWithLettersOrSpecialCharacters_InvalidTest(string phoneNr)
        {
            var employee = new Employee("Testname", "TestLastName", new DateTime(2005, 10, 13),
                               new DateTime(1997, 11, 16), 15000, 2, phoneNr, "Jonts@gmail.com");

        }


    }
}
