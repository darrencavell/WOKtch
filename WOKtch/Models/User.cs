using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WOKtch.Models
{
    public class User
    {
        public int      UserId             { get; set; }
        public string   UserName           { get; set; }
        public string   UserEmail          { get; set; }
        public string   UserGender         { get; set; }
        public DateTime UserBirthDate      { get; set; }
        public string   UserPhoneNumber    { get; set; }
        public string   UserAddress        { get; set; }
        public string   UserProfilePicture { get; set; }
        public int      UserRole           { get; set; }
        public string   UserPassword       { get; set; }
    }
}