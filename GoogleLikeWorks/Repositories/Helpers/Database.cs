using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace GoogleLikeWorks.Repositories.Helpers
{
    internal static class Database
    {
        public static IDbConnection DbConnection()
        {
            IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["GoogleWorksConnection"].ConnectionString);

            if (db.State == ConnectionState.Closed)
            {
                db.Open();
            }

            return db;
        }
    }
}
