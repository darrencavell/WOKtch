using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WOKtch.Factories;
using WOKtch.Models;
using WOKtch.Utilities;

namespace WOKtch.Repositories
{
    public class UserRepository
    {
        // GETTING ALL THE ROWS FROM TABLE [USER]
        public static DataTable Get() {
            string query = "SELECT * FROM [User]";
            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            return dt;
        }
        // GETTING ALL THE ROWS FROM TABLE [USER] WITH THE SAME UserName
        public static User      Get(string UserEmail) {
            string query = string.Format("SELECT * FROM [User] WHERE UserEmail = '{0}'", UserEmail);
            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            User u = null;
            foreach (DataRow x in dt.Rows) {
                u = UserFactory.Create(x["UserName"].ToString(), 
                                            x["UserPassword"].ToString(), 
                                            Int32.Parse(x["UserRole"].ToString()));
            }
            return u;
        }
        // GETTING ALL THE ROWS FROM TABLE [USER] WITH THE SAME UserName, UserPassword
        public static User      Get(string UserEmail, string UserPassword) {
            string query = string.Format("SELECT * FROM [User] WHERE UserEmail = '{0}' AND UserPassword = '{1}'", UserEmail, UserPassword);
            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            User u = null;
            foreach(DataRow x in dt.Rows) {
                u = UserFactory.Create(Int32.Parse(x["UserId"].ToString()),
                                            x["UserName"].ToString(),
                                            x["UserEmail"].ToString(), 
                                            x["UserGender"].ToString(),
                                            DateTime.Parse(x["UserBirthDate"].ToString()),
                                            x["UserPhoneNumber"].ToString(),
                                            x["UserAddress"].ToString(),
                                            x["UserProfilePicture"].ToString(),
                                            Int32.Parse(x["UserRole"].ToString()), 
                                            x["UserPassword"].ToString());
            }
            return u;
        }
        public static User      GetById(int UserId)
        {
            string query = string.Format("SELECT * FROM [User] WHERE UserId = '{0}'", UserId);
            DataTable dt = DatabaseConnection.ExecuteQuery(query);
            User u = null;
            foreach (DataRow x in dt.Rows)
            {
                u = UserFactory.Create(Int32.Parse(x["UserId"].ToString()),
                                            x["UserName"].ToString(),
                                            x["UserEmail"].ToString(),
                                            x["UserGender"].ToString(),
                                            DateTime.Parse(x["UserBirthDate"].ToString()),
                                            x["UserPhoneNumber"].ToString(),
                                            x["UserAddress"].ToString(),
                                            x["UserProfilePicture"].ToString(),
                                            Int32.Parse(x["UserRole"].ToString()),
                                            x["UserPassword"].ToString());
            }
            return u;
        }

        // INSERTING ROWS TO TABLE [USER]
        public static void Insert(User u) {
            string query = string.Format("INSERT INTO [User](UserName, UserEmail, UserGender, UserBirthDate, UserPhoneNumber, UserPassword, UserAddress, UserProfilePicture, UserRole) VALUES('{0}','{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', {8})", u.UserName, u.UserEmail, u.UserGender, u.UserBirthDate, u.UserPhoneNumber, u.UserPassword, u.UserAddress, u.UserProfilePicture, u.UserRole);
            DatabaseConnection.ExecuteNonQuery(query);
        }
        // UPDATING UserRole(1) TO TABLE [USER]
        public static void Update(int Role, int UserId) {
            string query = string.Format("UPDATE [User] SET UserRole = {0} WHERE UserId = {1}", Role, UserId);
            DatabaseConnection.ExecuteNonQuery(query);
        }
        // DELETING ROWS FROM TABLE [USER]
        public static void Delete(int UserId) {
            string query = "DELETE [User] WHERE UserId = " + UserId;
            DatabaseConnection.ExecuteNonQuery(query);
        }
    }
}