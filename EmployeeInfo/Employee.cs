using System;
using System.Text.RegularExpressions;

namespace EmployeeInfo
{
    public class Employee
    {
        private int snabelCounter;
        private string firstName;
        private string lastName;
        private DateTime hireDate;
        private DateTime birthDate;
        private double salary;
        private double bonusProcent;
        private string phoneNr;
        private string email;


        public string FirstName //Logik i set delen max 15 tecken
        {
            get { return firstName; }
           
            set 
            {

                if (value.Length <= 15 && !String.IsNullOrEmpty(value))
                {
                    firstName = value;
                }
                else if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be empty");
                }   
                else
                {
                    throw new ArgumentOutOfRangeException("name is too long, max 15 letters.");

                }

            }

        }
        public string LastName // Max 20 bokstäver
        {
            get { return lastName; }

            set
            {

                if (value.Length <= 20 && !String.IsNullOrEmpty(value))
                {
                    lastName = value;
                }
                else if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Lastname cannot be empty");
                }
                else
                {
                    throw new ArgumentOutOfRangeException("name is too long, max 20 letters.");

                }

            }
        } 
        public DateTime HireDate //Inte framtiden, max 70 år tbx
        {
            get { return hireDate; }
            set 
            {
                if (value <= DateTime.Now && value >= DateTime.Now.AddYears(-70))
                {
                    hireDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("cannot be more than 70 years back, neither in the future");
                }
            }
        }
        public DateTime BirthDate //Inte framtiden
        {
            get { return birthDate; }

            set 
            {
                if (value <= DateTime.Now)
                {
                    birthDate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Cannot be in the future");
                }
            }
        }
        public double Salary //Decimaltal, inte negativt
        {
            get { return salary; }

            set 
            {
                if (value >= 0)
                {
                    salary = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Cannot be a negative value");
                }
            }
        }
        public double BonusProcent //Procent på lönen
        {
            get { return bonusProcent; }
           
            set 
            {
                if (value <= 100 && value >= 0)
                {
                    bonusProcent = (value / 100) * Salary;
                    bonusProcent = Math.Round(bonusProcent);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("cannot be a negative value or above 100");
                }
                 
            }
        }
        public string PhoneNr //Endast siffror, streck och mellanslag
        {
            get { return phoneNr; }

            set 
            {

                if (Regex.IsMatch(value, "^[0-9\\s-]*$"))
                {
                    phoneNr = value;
                }
                else
                {
                    throw new ArgumentException("Cannot contain anything else than digits, whitespace and -");
                }
            }
        }
        public string Email //Ingen whitespace. Innehåller @ och minst 1 punkt.
        {
            get { return email; }

            set 
            {
                value = value.Trim();

                if (!value.Contains(' ') && value.Contains('.'))
                {                    
                    for (int i = 0; i < value.Length; i++)
                    {
                        if (value[i] == '@')
                        {
                            snabelCounter += 1;
                        }
                        
                    }
                    if (snabelCounter == 1)
                    {
                        email = value;
                    }
                    else
                    {
                        throw new ArgumentException("Cannot contain more than one @");
                    }
                }
                else
                {
                    throw new ArgumentException("Cannot contain whitespace and has to contain a dot.");
                }
            }
        }


        public Employee(string firstName, string lastName, DateTime hireDate, DateTime birthDate, 
                        double salary, double bonusProcent, string phoneNr, string email)
        {
           this.FirstName = firstName;
           this.LastName = lastName;
           this.HireDate = hireDate;
           this.BirthDate = birthDate;
           this.Salary = salary;
           this.BonusProcent = bonusProcent;
           this.PhoneNr = phoneNr;
           this.Email = email;
        }

    }
}
