namespace Assessment.Application.Helpers
{
    public static class GeneralUtility
    {
        public static string GenerateRandomString(int length, string id = "")
        {
            string capitalAlphabets = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string smallAlphabets = "abcdefghijklmnopqrstuvwxyz";
            string numbers = "1234567890";

            string characters = numbers + capitalAlphabets + smallAlphabets + id;
            string password = string.Empty;
            for (int i = 0; i < length; i++)
            {
                string character = string.Empty;
                do
                {
                    int index = new Random().Next(0, characters.Length);
                    character = characters.ToCharArray()[index].ToString();
                } while (password.IndexOf(character) != -1);
                password += character;
            }
            return password;
        }

    }
}
