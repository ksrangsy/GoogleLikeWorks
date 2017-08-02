using System.Collections.Generic;
using System.Linq;
using Dapper;
using GoogleLikeWorks.Models;
using System.Data;
using GoogleLikeWorks.Repositories.Helpers;

namespace GoogleLikeWorks.Repositories
{
    public static class TestTableRepository
    {
        public static List<TestTableModel> GetAll()
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var testTables = db.Query<TestTableModel>("SELECT * FROM TestTable").ToList();

                return testTables;
            }
        }
    }
}
