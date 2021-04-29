using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{

    [TestClass]
    public class FirstNameTests
    {
        Employee employee1 = new Employee("Jonte", "Kullman", new DateTime(2015, 05, 13), new DateTime(1997, 11, 16), 35000, 15.3, "072 - 3225633", "Jontekullz@gmail.com");
        Employee employee2 = new Employee("Titte", "Petigsson", new DateTime(2011, 10, 04), new DateTime(1995, 06, 18), 15000, 13.8, "070-8245662", "Titte.Boy@gmail.com");
        Employee employee3 = new Employee("Sven-Göran", "Olsson", new DateTime(1996, 02, 25), new DateTime(1969, 02, 27), 22000, 8, "073 - 9265638", "Sven.göran@gmail.com");


        //#############################################################################################################
        //                        Testar firstname propertyn med 3 instanser av employees nedan. 

        [TestMethod]
        public void FirstNameOnThreeInstancedEmployees_Valid()
        {
            try
            {

                employee1.FirstName = "Jonathan";
                employee2.FirstName = "Tintin";
                employee3.FirstName = "SvenfuckinGöran";

                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is AssertFailedException);
            }
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FirstNameOnThreeInstancedEmployeesTooLong_Invalid()
        {

                employee1.FirstName = "JonathanJonathan";

        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FirstNameOnThreeInstancedEmployeesIsEmpty_Invalid()
        {
                employee2.FirstName = "";

        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void FirstNameOnThreeInstancedEmployeesIsNull_Invalid()
        {
            employee3.FirstName = null;

        }



        //#############################################################################################################
        //                      DataRows metoder börjar här (1 instance av employee i metoderna)

        [TestMethod]
        [DataRow ("Jonathan")]
        [DataRow ("Tintin")]
        [DataRow ("Gandalf")]
        public void FirstName_ValidTest(string firstName)
        {
            try
            {
                Employee employee = new Employee(firstName, "LastTestName", new DateTime(2005, 10, 13),
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
                     
        Employee employee = new Employee(firstName, "LastTestName", new DateTime(2005, 10, 13),
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
            Employee employee = new Employee(firstName, "LastTestName", new DateTime(2005, 10, 13),
                        new DateTime(1997, 11, 16), 34000, 2, "0723225639", "Jonts@gmail.com");

        }
            
    }
}
