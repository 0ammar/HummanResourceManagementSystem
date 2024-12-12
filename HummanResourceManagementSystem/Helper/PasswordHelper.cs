using System.Text;

namespace HummanResourceManagementSystem.Helper
{
    public class PasswordHelper
    {
        static string GeneratePassword(int length)
        {
            if (length < 6)
                throw new ArgumentException("Password length must be at least 6 characters.");

           
            const string lowercase = "abcdefghijklmnopqrstuvwxyz";
            const string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string digits = "0123456789";
            const string symbols = "!@#$%^&*()-_=+[]{};:,.<>?";

            
            Random random = new Random();
            StringBuilder passwordBuilder = new StringBuilder();

            passwordBuilder.Append(lowercase[random.Next(lowercase.Length)]);
            passwordBuilder.Append(uppercase[random.Next(uppercase.Length)]);
            passwordBuilder.Append(digits[random.Next(digits.Length)]);
            passwordBuilder.Append(symbols[random.Next(symbols.Length)]);

            string allCharacters = lowercase + uppercase + digits + symbols;
            for (int i = 4; i < length; i++)
            {
                passwordBuilder.Append(allCharacters[random.Next(allCharacters.Length)]);
            }

            char[] passwordArray = passwordBuilder.ToString().ToCharArray();
          

            return new string(passwordArray);
        }
    }
}
