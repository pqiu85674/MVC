using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace MVC.Models;
public class Data(IConfiguration configuration)
{

    private readonly IConfiguration _configuration = configuration;

    public IEnumerable<Datatype> GetData()
    {
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var DATA = cn.Query<Datatype>("SELECT * FROM DATA");
            return DATA;
        }
    }

}