using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WOKtch.Models;

namespace WOKtch.Factories
{
    public class UserFactory
    {
        public static User Create(string UserName, string UserPassword) {
            User u = new User();
            u.UserName = UserName;
            u.UserPassword = UserPassword;
            return u;
        }
        public static User Create(string UserName, string userPassword, int UserRole) {
            User u = new User();
            u.UserName = UserName;
            u.UserPassword = userPassword;
            u.UserRole = UserRole;
            return u;
        }
        public static User Create(string UserName, string userPassword, DateTime dob, int UserRole)
        {
            User u = new User();
            u.UserName = UserName;
            u.UserPassword = userPassword;
            u.UserBirthDate = dob;
            u.UserRole = UserRole;
            return u;
        }
        public static User Create(string UserName, string userPassword, string gender, DateTime dob, string email, string address, string phoneNumber, string profile, int UserRole)
        {
            User u = new User();
            u.UserName = UserName;
            u.UserPassword = userPassword;
            u.UserGender = gender;
            u.UserBirthDate = dob;
            u.UserEmail = email;
            u.UserAddress = address;
            u.UserPhoneNumber = phoneNumber;
            u.UserProfilePicture = profile;
            u.UserRole = UserRole;
            return u;
        }
        public static User Create(int UserId, string UserName, string UserEmail, string UserGender, DateTime UserBirthDate, string UserPhoneNumber, string UserAddress, string UserProfilePicture, int UserRole, string UserPassword)
        {
            User u = new User();
            u.UserId = UserId;
            u.UserName = UserName;
            u.UserEmail = UserEmail;
            u.UserGender = UserGender;
            u.UserBirthDate = UserBirthDate;
            u.UserPhoneNumber = UserPhoneNumber;
            u.UserAddress = UserAddress;
            u.UserProfilePicture = UserProfilePicture;
            u.UserRole = UserRole;
            u.UserPassword = UserPassword;
            return u;
        }
    }
}