﻿namespace HummanResourceManagementSystem.Helper
{
    public static class PhoneNumberValidationHelper
    {

        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) 
                return false;

            if (IsJordanianPhoneNumber(phoneNumber))
                return true;

            else return (IsInternationalPhoneNumber(phoneNumber));
            
        }

        // To check if the given input is a Jordanian  number
        public static bool IsJordanianPhoneNumber(string PhoneNumber)
        {
            if (PhoneNumber.StartsWith("07") && PhoneNumber.Length == 10)
            {
                if (PhoneNumber[2] == 7 || PhoneNumber[2] == 8 || PhoneNumber[2] == 9)
                {
                    for (int i = 3; i < PhoneNumber.Length; i++)
                    {
                        if (char.IsDigit(PhoneNumber[i]))
                        { return true; }

                        
                    } return false;
                }
                else { return false; }
            }
            else { return false; }


        }

        // To check if the given input is a International  number
        public static bool IsInternationalPhoneNumber(string PhoneNumber)
        {
            // Check the total length it should be between 9 and 15
            if (PhoneNumber.Length < 9 || PhoneNumber.Length > 15) 
            { return false; }

            // Check if it starts with '+' 
            if (PhoneNumber[0]!='+')
            { return false; }

            // Check if the rest of the input are digits
            for (int i = 1; i < PhoneNumber.Length; i++)
            {
                if (!char.IsDigit(PhoneNumber[i]))
                { return false; }


            }
            return true;
        }

    }
}

