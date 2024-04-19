namespace businessStaff2.Models
{
  public class Employee
  {
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Address { get; set; }
    public string? Document { get; set; }
    public string? Phone { get; set; }
    public string? Status { get; set; }
    public string? Position { get; set; }
    public DateTime? CreationTime { get; set; }
  }
}