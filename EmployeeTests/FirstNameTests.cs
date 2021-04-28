using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{
    [TestClass]
    public class FirstNameTests
    {
        [TestMethod]
        [DataRow ("Jonathan")]
        [DataRow ("Tintin")]
        [DataRow ("Gandalf")]
        public void FirstName_ValidTest(string firstName)
        {
            try
            {
                var employee = new Employee(firstName, "LastTestName", new DateTime(2005, 10, 13),
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
        [DataRow ("")]
        public void FirstNameEmpty_InvalidTest(string firstName)
        {
                     
        var employee = new Employee(firstName, "LastTestName", new DateTime(2005, 10, 13),
                        new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");
        
        Assert.Fail();
            
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [DataRow ("HelloHelloKalleBoy")]
        [DataRow ("HelloHelloBondeBoy")]
        [DataRow ("HelloHelloTintinBoy")]
        public void FirstNameTooLong_InvalidTest(string firstName)
        {
            var employee = new Employee(firstName, "LastTestName", new DateTime(2005, 10, 13),
                        new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");

        }
            
    }
}
