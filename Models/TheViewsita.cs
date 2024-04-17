namespace businessStaff2.Models;
public class TheViewSitaModel
{
    public int Id { get; set; }
    public int IdUser { get; set; }
    public string? FirstName { get; set; }
    public DateTime? EntryHour { get; set; }
    public DateTime? DepartureHour { get; set; }
}
