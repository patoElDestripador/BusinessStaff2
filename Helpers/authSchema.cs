using System.Security.Principal;

public interface ICustomPrincipal : IPrincipal
{
    string FirstName { get; set; }
 
    string LastName { get; set; }
}