namespace businessStaff2.Helpers
{
    public  class TheHelpercito
    {
        public string someting(string hello)
        {
            return "Hello";
        }
    /*


        se agg esta linea en el inicio de sesion 
            HttpContext.Session.SetString("UsuarioNombre", usuario.Nombre);

            esta para obteer ;ps datps 
    string nombreUsuario = HttpContext.Session.GetString("UsuarioNombre");

    */

       public static string GenerateUserName(string FirstName, string LastName, string Document)
        {
            string cleanFirstName = FirstName.Trim().ToLower();
            string cleanLastName = LastName.Trim().ToLower();
            string cleanDocument = Document.Trim();
            string username = $"{cleanFirstName[0]}{cleanLastName}{cleanDocument.Substring(cleanDocument.Length - 2)}";
            return username;
        }
    }
}
