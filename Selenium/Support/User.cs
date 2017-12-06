using System;

namespace Selenium.Support
{
    public class User
    {
        public Title Title => Title.Mrs;
        public string FirstName => "Iris";
        public string LastName => "West-Allen";
        public string Email;
        public string Password => "Password1234";
        public DateTime DateOfBirth => new DateTime(1989, 6, 24);
        public string Address => "123 Main Street";
        public string City => "Central City";
        public State State => State.Washington;
        public string Zip => "99000";
        public Country Country => Country.UnitedStates;
        public string MobilePhone => "509-555-1234";
        public string AddressAlias => "Home";

        public User()
        {
            Email = GenerateEmail();
        }

        private string GenerateEmail()
        {
            Random randomNumber = new Random();
            
            return $"{FirstName}.{LastName}{randomNumber.Next(100, 999)}@test.com";
        }
    }
}
