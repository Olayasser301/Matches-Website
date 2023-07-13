namespace web.Models;
public class Fan{
    public string name { get; set; } = string.Empty;
     public  int nationalId { get; set; }
     public string username { get; set; } = string.Empty;
     public DateTime birth_date{get; set;} 
     public bool status{get; set;}
     public int Phone_num{get; set;}
     public string address{get; set;}=string.Empty;
}