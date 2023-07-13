using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
namespace project.Pages.ClubRepresentative;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";
    public List<club_representative> Club_Representatives = new List<club_representative>();


    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        _logger.LogInformation("Connected to the database!");

        String sql = "SELECT CR_name, Club_Representitave.id , username, Club_name FROM Club_Representitave INNER JOIN Club ON Club_Representitave.Club_id = Club.id ";
        SqlCommand command = new SqlCommand(sql, conn);
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteReader();    
        _logger.LogInformation("Created the data reader.");

        while (reader.Read()) {

            _logger.LogInformation("Reading line.");
            Club_Representatives.Add(new club_representative  {
                name = reader.GetString(0),
                id = reader.GetInt32(1),
                username = reader.GetString(2)
            });
        }

       // _logger.LogInformation("Read clients count: " + sports_ass_manager.Count);

        conn.Close();
    }
    }

