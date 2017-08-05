using Dapper;
using GoogleLikeWorks.Models;
using GoogleLikeWorks.Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GoogleLikeWorks.Repositories
{
    public class ListRepository
    {
        public static List<ListsModel> GetAll()
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var lists = db.Query<ListsModel>("SELECT * FROM Lists").ToList();

                return lists;
            }
        }

        public static Tuple<ListsModel, List<PagesModel>, List<TasksModel>> Get(int id)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"SELECT * FROM Lists WHERE id = @id;
                    SELECT * FROM Pages WHERE ListID = @id;
                    SELECT b.* FROM Pages a INNER JOIN Tasks b ON a.ID = b.PageID WHERE a.ListID = @id;";

                using (var multi = db.QueryMultiple(sql, new { id = id }))
                {
                    var list = multi.Read<ListsModel>().FirstOrDefault();
                    var pages = multi.Read<PagesModel>().ToList();
                    var tasks = multi.Read<TasksModel>().ToList();

                    var result = new Tuple<ListsModel, List<PagesModel>, List<TasksModel>>(list, pages, tasks);

                    return result;
                }
            }
        }

        public static int NewList(string title)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"INSERT INTO Lists(Title) VALUES(@title);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                var id = db.Query<int>(sql, new { title = title }).SingleOrDefault();

                return id;
            }
        }

        public static void DeleteList(int id)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"DELETE Lists WHERE ID = @id;";

                var results = db.Execute(sql, new { id = id });
            }
        }

        public static void UpdateList(int id, string title)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"UPDATE Lists SET Title = @title WHERE ID = @id;";

                var results = db.Execute(sql, new { id = id, title = title });
            }
        }
    }
}
