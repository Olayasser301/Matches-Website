using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using web.Models;
namespace project.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    //private String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";
   // public List<System_admin> SystemAdmins = new List<System_admin>();


    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {

       
    }
}
