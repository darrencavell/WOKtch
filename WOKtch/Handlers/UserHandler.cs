using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WOKtch.Factories;
using WOKtch.Models;
using WOKtch.Repositories;

namespace WOKtch.Handlers
{
    public class UserHandler
    {
        public static DataTable Get()                                        { return UserRepository.Get();                       }              // Member
        public static User      Get(string UserEmail)                        { return UserRepository.Get(UserEmail);              }              // Register             
        public static User      Get(string UserEmail, string UserPassword)   { return UserRepository.Get(UserEmail, UserPassword);}              // Login
        public static User      GetById(int UserId)                          { return UserRepository.GetById(UserId);             }              // Delete

        public static void Insert(string userName, string userPassword, string gender, DateTime dob, string email, string address, string phoneNumber, string image, int userRole)
            { User u = UserFactory.Create(userName, userPassword, gender, dob, email, address, phoneNumber, image, userRole); UserRepository.Insert(u);            }              // Register
        public static void Update(int Role, int UserId)
            { UserRepository.Update(Role, UserId);                                                                                                                 }              // Member         
        public static void Delete(int UserId)
            { UserRepository.Delete(UserId);                                                                                                                       }              // Member    
        
    }
}