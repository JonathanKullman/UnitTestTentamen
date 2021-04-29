using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using EmployeeInfo;

namespace EmployeeTests
{
    [TestClass]
    public class ConstructorTests
    {

        [TestMethod]
        [DataRow ("Test1", "Test1Last", "2003-11-05", "1966-03-22", 34000, 17.5, "0723225635", "Test1@gmail.com")]
        [DataRow ("Test2", "Test2Last", "1998-09-15", "1978-08-17", 45000, 2.2, "072 - 3225635", "Test_2@gmail.com")]
        [DataRow ("Test3", "Test3Last", "2018-06-03", "2000-10-04", 26000, 4, "072-3225635", "Test.1@gmail.com")]
        public void Constructor_ValidTest(string firstName, string lastName, string hireDate, 
                                          string birthDate, double salary, double bonusProcent, 
                                          string phoneNr, string email )

        {
            try
            {
                Employee employee = new Employee(firstName, lastName, DateTime.Parse(hireDate), 
                                                 DateTime.Parse(birthDate), salary, bonusProcent, 
                                                 phoneNr, email);

                Assert.Fail();
            }
            catch (Exception ex)
            {

                Assert.IsTrue(ex is AssertFailedException);
            }


        }


        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]
        //[DataRow("", "Test1Last", "2003-11-05", "1966-03-22", 34000, 17.5, "0723225635", "Test1@gmail.com")] // Firstname empty
        //[DataRow("Test2", "Test2LastNameTooLonggg", "1998-09-15", "1978-08-17", 45000, 2.2, "072 - 3225635", "Test_2@gmail.com")] // Lastname too long
        //[DataRow("Test3", "Test3Last", "1950-06-03", "2000-10-04", 26000, 4, "072-3225635", "Test.1@gmail.com")] // HireDate to far into the past
        //[DataRow("Test4", "Test4Last", "2018-06-03", "2021-10-04", 26000, 4, "072-3225635", "Test.1@gmail.com")] // BirthDate future
        //[DataRow("Test5", "Test5Last", "2018-06-03", "2000-10-04", -15000, 4, "072-3225635", "Test.1@gmail.com")] // Salary negative
        //[DataRow("Test6", "Test6Last", "2018-06-03", "2000-10-04", 26000, 101, "072-3225635", "Test.1@gmail.com")] // BonusProcent above 100
        //[DataRow("Test7", "Test7Last", "2018-06-03", "2000-10-04", 26000, 4, "072_#¤3225635", "Test.1@gmail.com")] // PhoneNumber unaccepted character
        //[DataRow("Test8", "Test8Last", "2018-06-03", "2000-10-04", 26000, 4, "072-3225635", "Test.1@@gmail.com")] // Email two @
        //public void Constructor_InvalidTest(string firstName, string lastName, string hireDate,
        //                                   string birthDate, double salary, double bonusProcent,
        //                                   string phoneNr, string email)
        //{
        //    Employee employee = new Employee(firstName, lastName, DateTime.Parse(hireDate),
        //                                        DateTime.Parse(birthDate), salary, bonusProcent,
        //                                        phoneNr, email);
        //}

    }
}
