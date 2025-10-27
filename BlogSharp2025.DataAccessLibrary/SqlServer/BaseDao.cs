using Microsoft.Data.SqlClient; //Sql implementation
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSharp2025.DataAccessLibrary.SqlServer;
public abstract class BaseDao
{
    public string ConnectionString { get; private set; }

    protected BaseDao(string connectionString)
    {
            ConnectionString = connectionString;
    }

    public IDbConnection CreateConnection()
    {
        //Microsoft.Data.SqlClient
        return new SqlConnection(ConnectionString);
    }

}
