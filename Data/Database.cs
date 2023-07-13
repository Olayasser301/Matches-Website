using web.Models;
using System.Data.SqlClient;

namespace project.Data;
    
class Database {
    private static String _connectionString = "Server=localhost;Database=model;Trusted_Connection=false;User Id=sa;Password=5uper5trongPW!;";

    public static List<Stadium> GetStadiums() {
     List<Stadium> stadiums = new List<Stadium>();
        SqlConnection conn = new SqlConnection(_connectionString);
        conn.Open();

        String sql = "SELECT * FROM stadium";
        SqlCommand command = new SqlCommand(sql, conn);
        var reader = command.ExecuteReader();    
        while (reader.Read()) {
            stadiums.Add(new Stadium  {
                id = reader.GetInt32(1),
                Staduim_name = reader.GetString(0),
                Locations = reader.GetString(2),
                Statuss = reader.GetBoolean(3),
                Capacity = reader.GetInt32(4)
            });
        }

       // _logger.LogInformation("Read clients count: " + sports_ass_manager.Count);

        conn.Close();

        return stadiums;
    }
}