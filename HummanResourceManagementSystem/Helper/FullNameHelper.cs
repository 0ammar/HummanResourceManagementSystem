namespace HummanResourceManagementSystem.Helper
{
    public static class FullNameHelper
    {
        public static bool IsNameCompatable1(string FirstName, string MiddleName, string LastName)
        {
            bool isFirstNameEnglish = IsEnglish(FirstName);
            bool isMiddleNameEnglish = IsEnglish(MiddleName);
            bool isLastNameEnglish = IsEnglish(LastName);
            bool isFirstNameArabic = IsArabic(FirstName);
            bool isMiddleNameArabic = IsArabic(MiddleName);
            bool isLastNameArabic = IsArabic(LastName);

            if ((isFirstNameEnglish && isMiddleNameEnglish && isLastNameEnglish) || (isFirstNameArabic && isMiddleNameArabic && isLastNameArabic))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsEnglish(string input)
        {
            return input.All(c => (c >= '\u0041' && c <= '\u005A') || (c >= '\u0061' && c <= '\u007A'));
        }

        public static bool IsArabic(string input)
        {
            return input.All(c => (c >= '\u0600' && c <= '\u06FF'));
        }
    }
}
