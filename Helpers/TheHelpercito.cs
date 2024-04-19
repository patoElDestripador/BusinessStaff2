namespace businessStaff2.Helpers
{
    public  class TheHelpercito
    {
       public static string GenerateUserName(string FirstName, string LastName, string Document)
        {
            string cleanFirstName = FirstName.Trim().ToLower();
            string cleanLastName = LastName.Trim().ToLower();
            string cleanDocument = Document.Trim();
            string username = $"{cleanFirstName[0]}{cleanLastName}{cleanDocument.Substring(cleanDocument.Length - 2)}";
            return username;
        }
        public static string Encrypt(string encrypt)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(encrypt);
            string result = Convert.ToBase64String(encryted);
            return result;
        }

        public static string Decrypt(string decrypt)
        {
            byte[] decryted = Convert.FromBase64String(decrypt);
            string result =  System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }

    }


    
}


