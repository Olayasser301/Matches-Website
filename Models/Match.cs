namespace web.Models;
public class Match{
    public DateTime start_time  { get; set; }
     public DateTime end_time  { get; set; }
    public  int  Host_club_id { get; set; }
    public  int Guest_club_id { get; set; }
    public  int Stadium_id { get; set; }
     public  int id { get; set; }

     public string Hostname{get;set;}=String.Empty;
     public string Guestname{get;set;}=String.Empty;

}