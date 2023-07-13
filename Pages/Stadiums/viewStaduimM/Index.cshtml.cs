using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
namespace project.Pages.Stadiums.viewStaduimM;

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
        String sql = "SELECT Staduim_name ,Locations , Statuss ,Capacity FROM Staduim INNER JOIN Staduim_manager ON Staduim.id = Staduim_manager.Staduim_id ";
        SqlCommand command = new SqlCommand(sql, conn);
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteReader();    
        _logger.LogInformation("Created the data reader.");

        while (reader.Read()) {

            _logger.LogInformation("Reading line.");
            stadiums.Add(new Stadium{
                id = reader.GetInt32(0),
                Staduim_name = reader.GetString(1),
                Locations = reader.GetString(2),
                Statuss = reader.GetBoolean(3),
                Capacity = reader.GetInt32(4)
            });
        }

      // _logger.LogInformation("Read clients count: " + Club.Count);

        conn.Close();
    }
    }

