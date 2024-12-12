namespace HummanResourceManagementSystem.Helper
{
    public static class EmailHelper
    {
        public static bool IsValidEmail(string email)
        {

            if (!string.IsNullOrEmpty(email))
            {

                if (email.Contains("@") && email.EndsWith(".com"))
                {

                    string domain = email.Substring(email.IndexOf("@"));

                    if (domain == "@gmail.com" || domain == "@live.com" || domain == "@outlook.com" || domain == "@yahoo.com" || domain == "@hotmail.com")
                    {
                        return true;
                    }
                }
            }
            return false;

        }
    }
}
