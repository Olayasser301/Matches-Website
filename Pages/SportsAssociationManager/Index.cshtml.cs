using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
namespace project.Pages.SportsAssociationManager;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";
    public List<Sports_Assosciation_manager> sports_Assosciation_Managers = new List<Sports_Assosciation_manager>();


    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        _logger.LogInformation("Connected to the database!");

        String sql = "SELECT SAM_name, id , username FROM Sports_Assosciation_manager";
        SqlCommand command = new SqlCommand(sql, conn);
        _logger.LogInformation("Created the command correctly.");

        var reader = command.ExecuteReader();    
        _logger.LogInformation("Created the data reader.");

        while (reader.Read()) {

            _logger.LogInformation("Reading line.");
            sports_Assosciation_Managers.Add(new Sports_Assosciation_manager  {
                name = reader.GetString(0),
                id = reader.GetInt32(1),
                username = reader.GetString(2)
            });
        }

       // _logger.LogInformation("Read clients count: " + sports_ass_manager.Count);

        conn.Close();
    }
    }

