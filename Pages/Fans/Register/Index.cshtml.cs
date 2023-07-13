using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;

namespace project.Pages.Fans.Register;

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
        String sql2 ="INSERT INTO Fan(Fan_name,nationalId, username,birth_date,Phone_num,Addresss, Statuss) VALUES(@name,@id,@username,@birthd,@num,@address,1 )";
        SqlCommand commands = new SqlCommand(sql2, conn);
        commands.Parameters.AddWithValue("@name", Request.Form["Fan_name"].ToString());
        commands.Parameters.AddWithValue("@id", Request.Form["nationalId"].ToString());
        commands.Parameters.AddWithValue("@username", Request.Form["username"].ToString());
        commands.Parameters.AddWithValue("@birthd", DateTime.Parse(Request.Form["birth_date"].ToString()));
        commands.Parameters.AddWithValue("@num", Request.Form["Phone_num"].ToString());
        commands.Parameters.AddWithValue("@address", Request.Form["Addresss"].ToString());

        _logger.LogInformation("Created the command correctly.");
        var readers = commands.ExecuteNonQuery();    
        _logger.LogInformation("Inserted the data.");

        Response.Redirect("/");
    }
}