namespace HummanResourceManagementSystem.Helper
{
    public static class FullNameValidationHelper
    {
        public static bool IsNameValid(string FirstName, string MiddleName, string LastName)
        {
            return IsAllArabic(FirstName) && IsAllArabic(MiddleName) && IsAllArabic(LastName) ||
                        IsAllEnglish(FirstName) && IsAllEnglish(MiddleName) && IsAllEnglish(LastName);

        }
        public static bool IsAllEnglish(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if ((input[i] >= '\u0041' && input[i] <= '\u005A') || (input[i] >= '\u0061' && input[i] <= '\u007A'))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        public static bool IsAllArabic(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= '\u0600' && input[i] <= '\u06FF')
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}

