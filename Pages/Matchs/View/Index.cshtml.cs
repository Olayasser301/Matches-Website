using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
namespace project.Pages.Matchs.View;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";
    public List<Match> Matches= new List<Match>();


    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        _logger.LogInformation("Connected to the database!");

        String sql = "SELECT * FROM allMatches";
        SqlCommand command = new SqlCommand(sql, conn);
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteReader();    
        _logger.LogInformation("Created the data reader.");

        while (reader.Read()) {

            _logger.LogInformation("Reading line.");
            Matches.Add(new Match{
                Hostname = reader.GetString(0),
                Guestname = reader.GetString(1),
                 start_time = reader.GetDateTime(2),
                end_time = reader.GetDateTime(3)
                
            });
        }

      // _logger.LogInformation("Read clients count: " + Club.Count);

        conn.Close();
    }
    }

