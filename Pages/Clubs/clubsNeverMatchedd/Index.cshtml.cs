using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
using System.Data;
namespace project.Pages.Clubs.clubsNeverMatchedd;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";
    public List<clubsNeverMatched> Clubss= new List<clubsNeverMatched>();


    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

    
        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();
      //var query = "clubsNeverMatched";
      //using var command = new SqlCommand(query, conn);
      //command.CommandType = CommandType.StoredProcedure;
        _logger.LogInformation("Connected to the database!");

        String sql = "SELECT * FROM clubsNeverMatched";
        SqlCommand command = new SqlCommand(sql, conn);

        var reader = command.ExecuteReader();    
        _logger.LogInformation("Created the data reader.");

        while (reader.Read()) {

            _logger.LogInformation("Reading line.");
             Clubss.Add(new clubsNeverMatched{
              Host_name = reader.GetString(0),
             Guest_name = reader.GetString(1)
            });
        }

      // _logger.LogInformation("Read clients count: " + Club.Count);

        conn.Close();
    }
    }

