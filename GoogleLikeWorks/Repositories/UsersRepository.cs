using System.Collections.Generic;
using System.Linq;
using Dapper;
using GoogleLikeWorks.Models;
using System.Data;
using GoogleLikeWorks.Repositories.Helpers;

namespace GoogleLikeWorks.Repositories
{
    public class UsersRepository
    {
        public static List<UsersModel> GetAll()
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var users = db.Query<UsersModel>("SELECT * FROM Users").ToList();

                return users;
            }
        }

        public static UsersModel GetUser(int id)
        {
            using (IDbConnection db = Database.DbConnection())
            {
                var user = db.QueryFirstOrDefault<UsersModel>("SELECT * FROM Users WHERE ID = ?", new { id = id });

                return user;
            }
        }
    }
}
