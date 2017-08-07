using Dapper;
using GoogleLikeWorks.Models;
using GoogleLikeWorks.Repositories.Helpers;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GoogleLikeWorks.Repositories
{
    internal class TasksRepository
    {
        internal static List<TasksModel> GetByList(int listID)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"SELECT Tasks.* FROM Pages INNER JOIN Tasks ON Pages.ID = Tasks.PageID WHERE Pages.ID = @id";
                var tasks = db.Query<TasksModel>(sql, new { id = listID }).ToList();

                return tasks;
            }
        }

        internal static List<TasksModel> GetByPage(int pageID)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"SELECT * FROM Tasks WHERE PageID = @id";
                var tasks = db.Query<TasksModel>(sql, new { id = pageID }).ToList();

                return tasks;
            }
        }

        internal static TasksModel Get(int taskID)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"SELECT * FROM Tasks WHERE id = @id;";
                var task = db.Query<TasksModel>(sql, new { id = taskID }).FirstOrDefault();

                return task;
            }
        }

        internal static int NewTask(int pageID, string blob)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"INSERT INTO Tasks(PageID, Blob) VALUES(@id, @blob);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";
                var id = db.Query<int>(sql, new { id = pageID, blob = blob }).SingleOrDefault();

                return id;
            }
        }

        internal static void DeleteTask(int taskID)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"DELETE Tasks WHERE ID = @id;";

                var results = db.Execute(sql, new { id = taskID });
            }
        }

        internal static void UpdateTask(int taskID, string blob)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var sql = @"UPDATE Tasks SET Blob = @blob WHERE ID = @id;";

                var results = db.Execute(sql, new { id = taskID, blob = blob });
            }
        }
    }
}
