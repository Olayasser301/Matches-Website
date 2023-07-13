using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;

namespace project.Pages.ClubRepresentative.Register;

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

        _logger.LogInformation("Connected to the database!");
        _logger.LogInformation("registerd");

        String sql =" INSERT INTO System_userr(username , Passwords)Values(@username ,@passwords)";
        SqlCommand command = new SqlCommand(sql, conn);
        command.Parameters.AddWithValue("@username", Request.Form["username"].ToString());
        command.Parameters.AddWithValue("@passwords", Request.Form["Passwords"].ToString());
            //logger.LogInformation("Created the command correctly.");
        var reader = command.ExecuteNonQuery();    
        
        String sql2 ="INSERT INTO Club_Representitave(CR_name, username, Club_id) VALUES(@name,@username, @id )";
        SqlCommand commands = new SqlCommand(sql2, conn);
        commands.Parameters.AddWithValue("@name", Request.Form["CR_name"].ToString());
        commands.Parameters.AddWithValue("@username", Request.Form["username"].ToString());
        commands.Parameters.AddWithValue("@id", Request.Form["Club_id"].ToString());
        _logger.LogInformation("Created the command correctly.");
        var readers = commands.ExecuteNonQuery();    
        _logger.LogInformation("Inserted the data.");

        String sql3 =" INSERT INTO Club(id)Values(@id)";
        SqlCommand commande = new SqlCommand(sql3, conn);
        commande.Parameters.AddWithValue("@id", Request.Form["id"].ToString());
        //commande.Parameters.AddWithValue("@passwords", Request.Form["Passwords"].ToString());
            //logger.LogInformation("Created the command correctly.");
        var readers2 = commande.ExecuteNonQuery();  
        Response.Redirect("/");
    }
}