using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BooksandAuthors
{
    public static class Validators
    {
        // Validates the phone number
        public static bool ValidatePhoneNumber(string phoneNumber)
        {

            string phonePattern = @"^\+?\d{10,13}$"; // Accepts + sign and 10-13 digits
            return Regex.IsMatch(phoneNumber, phonePattern);
        }

        // Validates the email address
        public static bool ValidateEmail(string email)
        {

            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        // Validates the date of birth (ensures age >= 18)
        public static bool ValidateDateOfBirth(DateTime dob)
        {
            int age = DateTime.Now.Year - dob.Year;
            if (dob > DateTime.Now.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}