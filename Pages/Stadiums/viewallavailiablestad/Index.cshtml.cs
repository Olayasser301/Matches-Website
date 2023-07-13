using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
namespace project.Pages.Stadiums.viewallavailiablestad;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";
    public List<Stadium> stadiums = new List<Stadium>();

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        _logger.LogInformation("Connected to the database!");
        String sql = "SELECT Staduim_name ,Locations , Capacity FROM Staduim WHERE Statuss = 1";
        SqlCommand command = new SqlCommand(sql, conn);
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteReader();    
        _logger.LogInformation("Created the data reader.");

        while (reader.Read()) {

            _logger.LogInformation("Reading line.");
            stadiums.Add(new Stadium{
                Staduim_name = reader.GetString(0),
                id = reader.GetInt32(1),
                Locations = reader.GetString(2)
            });
        }

      // _logger.LogInformation("Read clients count: " + Club.Count);

        conn.Close();
    }
    }

