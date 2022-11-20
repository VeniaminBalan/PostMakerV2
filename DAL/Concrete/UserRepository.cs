using DAL.Abstract;
using Dapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DAL.Concrete
{
    public class UserRepository : IUserRepository
    {
        public bool IsEmailUsed(string Email)
        {
            List<User> users;
            string sql = $"SELECT * FROM User_Account WHERE Email='{Email}'";

            using (var conection = new SqlConnection(DatabaseOptions.DatabaseConnectionString))
            {
                users = conection.Query<User>(sql).ToList();
            }

            if (users.Count == 0) return false;
            else return true;
        }

        public bool IsNameUsed(string Name)
        {
            List<User> users;
            string sql = $"SELECT * FROM User_Account WHERE Name='{Name}'";

            using (var conection = new SqlConnection(DatabaseOptions.DatabaseConnectionString))
            {
                users = conection.Query<User>(sql).ToList();
            }

            if (users.Count == 0) return false;
            else return true;
        }

        public User Login(User user)
        {
            string sql = $"SELECT * FROM User_Account WHERE Email='{user.Email}' AND Password='{user.Password}' ";
            User logedUser;

            using (var conection = new SqlConnection(DatabaseOptions.DatabaseConnectionString))
            {
                logedUser = conection.Query<User>(sql).FirstOrDefault();
            }
            return logedUser;
        }

        public void Signup(User user)
        {
            string sql = $"INSERT INTO User_Account (Email, Password, Name) VALUES ('{user.Email}','{user.Password}', '{user.Name}')";

            using (var conection = new SqlConnection(DatabaseOptions.DatabaseConnectionString))
            {
                conection.Execute(sql);
            }
        }
    }
}
