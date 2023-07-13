using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;

namespace project.Pages.Clubs.Delete;

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

        String sql = "DELETE from Club where Club_name = @name";
        SqlCommand command = new SqlCommand(sql, conn);
        _logger.LogInformation("Got following name= "+ Request.Form["Club_name"]);
        command.Parameters.AddWithValue("@name", Request.Form["Club_name"].ToString());
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteNonQuery();    
        _logger.LogInformation("Deleted the data.");

        Response.Redirect("/");
    }
}