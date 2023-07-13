using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
namespace project.Pages.Clubs.view;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";
    public List<Club> Clubss= new List<Club>();


    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        _logger.LogInformation("Connected to the database!");

        String sql = "SELECT Club_name , Club.id, Locations FROM Club , Club_Representitave WHERE Club.id= Club_Representitave.Club_id";
        SqlCommand command = new SqlCommand(sql, conn);
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteReader();    
        _logger.LogInformation("Created the data reader.");

        while (reader.Read()) {

            _logger.LogInformation("Reading line.");
            Clubss.Add(new Club{
                Club_name = reader.GetString(0),
                id = reader.GetInt32(1),
                Locations = reader.GetString(2)
            });
        }

      // _logger.LogInformation("Read clients count: " + Club.Count);

        conn.Close();
    }
    }

