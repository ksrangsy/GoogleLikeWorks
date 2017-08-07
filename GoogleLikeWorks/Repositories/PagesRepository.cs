using Dapper;
using GoogleLikeWorks.Models;
using GoogleLikeWorks.Repositories.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System;

namespace GoogleLikeWorks.Repositories
{
    internal class PagesRepository
    {
        internal static List<PagesModel> GetByList(int listID)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"SELECT * FROM Pages WHERE ListID = @id";
                var pages = db.Query<PagesModel>(sql, new { id = listID }).ToList();

                return pages;
            }
        }

        internal static PagesModel Get(int pageID)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"SELECT * FROM Pages WHERE id = @id;";

                var page = db.Query<PagesModel>(sql, new { id = pageID }).FirstOrDefault();

                return page;
            }
        }

        internal static int NewPage(int listID, string title)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"INSERT INTO Pages(ListID, Title) VALUES(@id, @title);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var id = db.Query<int>(sql, new { id = listID, title = title }).SingleOrDefault();

                return id;
            }
        }

        internal static void DeletePage(int pageID)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"DELETE Pages WHERE ID = @id;";

                var results = db.Execute(sql, new { id = pageID });
            }
        }

        internal static void UpdatePage(int pageID, string title)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"UPDATE Pages SET Title = @title WHERE ID = @id;";

                var results = db.Execute(sql, new { id = pageID, title = title });
            }
        }
    }
}
