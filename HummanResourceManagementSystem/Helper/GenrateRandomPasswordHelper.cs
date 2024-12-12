namespace HummanResourceManagementSystem.Helper
{
    public static class GenrateRandomPasswordHelper
    {
        public static string GenerateStrongPassword(int length)
        {
            Random random = new Random();


            if (length < 6)
            {
                return "false";
            }

            string lowerCaseLetters = "abcdefghijklmnopqrstuvwxyz";
            string upperCaseLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string digits = "0123456789";
            string symbols = "!@#$%^&*()_-+=<>?";

            char[] password = new char[length];
            password[0] = lowerCaseLetters[random.Next(lowerCaseLetters.Length)];
            password[1] = upperCaseLetters[random.Next(upperCaseLetters.Length)];
            password[2] = digits[random.Next(digits.Length)];
            password[3] = symbols[random.Next(symbols.Length)];

            string allCharacters = lowerCaseLetters + upperCaseLetters + digits + symbols;
            for (int i = 4; i < length; i++)
            {
                password[i] = allCharacters[random.Next(allCharacters.Length)];
            }

            return new string(password.OrderBy(x => random.Next()).ToArray());
        }
    }
}
