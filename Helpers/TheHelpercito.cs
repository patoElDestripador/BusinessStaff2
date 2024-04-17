using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using businessStaff2.Data;
using businessStaff2.Models;
using businessStaff2.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public static IActionResult Guardian (string userId)
        {
            Console.WriteLine("In guardian");
            if (string.IsNullOrEmpty(userId))
            {
                Console.WriteLine("Invalid data");
                return new RedirectToActionResult("Index", "Users", null);
            }
            Console.WriteLine("Valid data");
            throw new ArgumentException( "You must specify between 1 and 4 slices of bread.");
            return null ;
        }
    }
}
