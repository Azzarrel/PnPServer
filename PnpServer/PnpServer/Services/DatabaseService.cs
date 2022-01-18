using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PnPManager.Server.Services
{
  public class DatabaseService : IDatabaseService
  {

    private string ConnectionString;


    public DatabaseService()
    {
      ConnectionString = new SqlConnectionStringBuilder()
      {
        DataSource = ".\\SQLEXPRESS",
        InitialCatalog = "dbPnPManager",
        UserID = "sa",
        Password = "PnPAdmin666",
      }.ConnectionString;



    }

    public DataTable Login(string username, string password)
    {

      Dictionary<string, object> parameters = new Dictionary<string, object>();
      parameters["@Name"] = username;

      return ExecuteSP("usp_SelectUser", parameters);
    }

    public DataTable Register(string username, string password)
    {
      try
      {
        Dictionary<string, object> parameters = new Dictionary<string, object>();
        parameters["@Name"] = username;
        var table = ExecuteSP("usp_SelectUser", parameters);
        if(table == null && table.Rows.Count >= 0)
          throw new Exception("User already exists");

        parameters["@Password"] = password;
        parameters["@Guid"] = Guid.NewGuid();

        return ExecuteSP("usp_CreateUser", parameters);
      }
      catch(Exception e)
      {
        throw;
      }
    }

    public DataTable ExecuteSP(string sp, Dictionary<string, object> parameters)
    {

      DataTable tbl = new DataTable();
      try
      {
        using(SqlConnection connection = new SqlConnection(ConnectionString))
        {
          SqlCommand command = new SqlCommand(sp, connection);
          command.CommandType = CommandType.StoredProcedure;
          foreach(KeyValuePair<string, object> item in parameters)
          {
            command.Parameters.Add(new SqlParameter(item.Key, item.Value));
          }
          using(SqlDataAdapter adapter = new SqlDataAdapter(command))
          {

            var i = adapter.Fill(tbl);

          }
        }
      }
      catch(Exception e)
      {

      }
      return tbl;
    }



  }
}
