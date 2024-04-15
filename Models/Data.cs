using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
            var Data = cn.Query<Datatype>("SELECT * FROM DATA");
            return Data;
        }
    }
    public IEnumerable<Datatype> SelectData(string field, string value)
    {
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var GetData = new { select = field, value };
            var GetDate = new { value };
            var result = Enumerable.Empty<Datatype>();
            switch (field)
            {
                case "id":
                    result = cn.Query<Datatype>("Getdata", GetData, commandType: CommandType.StoredProcedure);
                    break;
                case "gender":
                    result = cn.Query<Datatype>("Getdata", GetData, commandType: CommandType.StoredProcedure);
                    break;
                case "datetime":
                    result = cn.Query<Datatype>("GetDate", GetDate, commandType: CommandType.StoredProcedure);
                    break;
                case "number":
                    result = cn.Query<Datatype>("Getdata", GetData, commandType: CommandType.StoredProcedure);
                    break;

            }
            return result;
        }
    }

}