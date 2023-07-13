using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;

namespace project.Pages.Clubs.New;

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
        _logger.LogInformation("New club is running");

        String sql = "INSERT INTO Club(Club_name, Locations) VALUES(@name , @Location)";
        SqlCommand command = new SqlCommand(sql, conn);
        //command.Parameters.AddWithValue("@id", Request.Form["id"].ToString());
        command.Parameters.AddWithValue("@name", Request.Form["Club_name"].ToString());
        command.Parameters.AddWithValue("@Location", Request.Form["Locations"].ToString());
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteNonQuery();    
        _logger.LogInformation("Inserted the data.");

        Response.Redirect("/");
    }
}