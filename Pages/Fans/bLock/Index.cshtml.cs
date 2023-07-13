using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;

namespace project.Pages.Fans.bLock;

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

       String sql = "UPDATE Fan SET Statuss = 0 WHERE nationalId = @nationalidd";
        SqlCommand command = new SqlCommand(sql, conn);
       // command.CommandType = CommandType.StoredProcedure;
      //  _logger.LogInformation("Got following name= "+ Request.Form["staduim_name"]);
        command.Parameters.AddWithValue("@nationalidd", Int32.Parse(Request.Form["nationalId"].ToString()));
        //command.Parameters.AddWithValue("@Status", Request.Form["Statuss"].ToString());

       //_logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteNonQuery();    
       // _logger.LogInformation("Deleted the data.");

        Response.Redirect("/");
    }

    // 1.  create a command object identifying the stored procedure

    // 2. set the command object so it knows to execute a stored procedure
    

    // 3. add parameter to command, which will be passed to the stored procedure

    // execute the command
   
}