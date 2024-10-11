using Dapper;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using static MVC.Controllers.HomeController;

namespace MVC.Models;
public class Data(IConfiguration configuration)
{
    private readonly IConfiguration _configuration = configuration;

    public IEnumerable<ColumnName> getColumnName(string tableName)
    {
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@tableName", tableName, DbType.String);
            var columnName = cn.Query<ColumnName>("getColumnName", parameters, commandType: CommandType.StoredProcedure);
            return columnName;
        }
    }

    public IEnumerable<T> selectData<T>(string tableName ,string columnName, string orderBy,string search)
    {
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@tableName", tableName, DbType.String);
            parameters.Add("@columnName", columnName, DbType.String);
            parameters.Add("@orderBy", orderBy, DbType.String);
            parameters.Add("@search", search, DbType.String);
            var Data = cn.Query<T>("selectData", parameters, commandType: CommandType.StoredProcedure);
            return Data;
        }
    }


    public IEnumerable<Users> GetUsersData(int column,string dir,string search)
    {
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var columnName = getColumnName("users").ToList();
            var selectColumnName = columnName[column].column_name;
            var data = selectData<Users>("users", selectColumnName, dir, search);
            return data;
        }
    }
    public IEnumerable<Products> GetProductsData(int column, string dir, string search)
    {
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var columnName = getColumnName("products").ToList();
            var selectColumnName = columnName[column].column_name;
            var data = selectData<Products>("products", selectColumnName, dir, search);
            return data;
        }
    }
    public IEnumerable<ShopCar> GetShopCarData(int column, string dir, string search)
    {
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var columnName = getColumnName("shopCar").ToList();
            var selectColumnName = columnName[column].column_name;
            var data = selectData<ShopCar>("shopCar", selectColumnName, dir, search);
            return data;
        }
    }
    public IEnumerable<getJoin> GetJoin(int column,string dir,string search)
    {
        var columnName = new string[] { "userName", "productName", "count", "price","dateAdded" };
        string ConnectionString = _configuration.GetConnectionString("DefaultConnection");
        using (var cn = new SqlConnection(ConnectionString))
        {
            cn.Open();
            var parameters = new DynamicParameters();
            parameters.Add("@columnName", columnName[column], DbType.String);
            parameters.Add("@search", search, DbType.String);
            parameters.Add("@orderBy", dir, DbType.String);
            var data = cn.Query<getJoin>("getJoin", parameters, commandType: CommandType.StoredProcedure);
            return data;
        }
    }
}