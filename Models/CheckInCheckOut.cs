namespace businessStaff2.Models;

public class CheckInCheckOut
{
    public int ID { get; set; }
    public int IdUser { get; set; }
    public DateTime EntryHour { get; set; }
    public DateTime DepartureHour { get; set; }
}
