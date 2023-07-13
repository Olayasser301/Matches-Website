using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;
using web.Models;

namespace project.Pages.Matchs.New;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }

    public void OnPost() {
        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();
    
        var query = "addNewMatch";
        using var command = new SqlCommand(query, conn);
        command.CommandType = CommandType.StoredProcedure;

        _logger.LogInformation("Connected to the database!");
        _logger.LogInformation("New club is running");

       // String sql = "SELECT m.Host_club_id , m.Guest_club_id FROM Club C1 inner join Match m on m.Host_club_id= C1.id inner JOIN Club C2 on m.Guest_club_id =C2.id WHERE C2.Club_name = @Hostname AND C1.Club_name= @Guestname";
       // SqlCommand command = new SqlCommand(sql, conn);
       command.Parameters.AddWithValue("@Guestname", Request.Form["C1.Club_name"].ToString());
        command.Parameters.AddWithValue("@Hostname", Request.Form["C2.Club_name"].ToString());
        command.Parameters.AddWithValue("@start_time", DateTime.Parse(Request.Form["start_time"].ToString()));
        command.Parameters.AddWithValue("@end_time" ,DateTime.Parse(Request.Form["end_time"].ToString()));
        _logger.LogInformation("Created the command correctly.");

       var reader = command.ExecuteNonQuery();  
     //  String sql2 = "INSERT INTO Match(Guest_Club_id , Host_Club_id, start_time , end_time) VALUES(C1.Club_id , C2.Club_id, @start_time , @end_time)";
     //  SqlCommand commands = new SqlCommand(sql2,conn);
     //   commands.Parameters.AddWithValue("C2.Club_id", Request.Form["Guest_Club_id"].ToString());
      //  commands.Parameters.AddWithValue("C1.Club_id", Request.Form["Host_Club_id"].ToString());
      //  commands.Parameters.AddWithValue("@start_time", Request.Form["start_time"].ToString());
      //  commands.Parameters.AddWithValue("@end_time" ,Request.Form["end_time"].ToString());
        _logger.LogInformation("Created the command correctly.");
        _logger.LogInformation("Inserted the data.");
      //  var readers = commands.ExecuteNonQuery();  
        Response.Redirect("/");
    }
}