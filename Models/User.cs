using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using SelfServices.Utilities;

namespace SelfServices.Models
{
    public class User
    {
        public string Username { get; set; }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string CustomerId { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurtiyAnswer { get; set; }

        public User() { }

        public User(string username, string password, string customerId, string securityQuestion, string securityAnswer)
        {
            Username = username;
            Password = password;
            CustomerId = customerId;
            SecurityQuestion = securityQuestion;
            SecurtiyAnswer = securityAnswer;
        }

        private static string HashPassword(string password)
        {
            MD5 hasher = MD5.Create();
            byte[] hashBytes=hasher.ComputeHash(Encoding.UTF8.GetBytes(password));
            string hash = Encoding.UTF8.GetString(hashBytes);
            return hash;
        }

        public static bool IsRegistered(User user)
        {
            return DataAccessHelper.IsUserExists(user);            
        }

        public static bool TryRegister(User user)
        {
            if(DataAccessHelper.IsUserNameAvailable(user.Username) && DataAccessHelper.IsCustomerIdAvailable(user.CustomerId))
            {
                DataAccessHelper.RegisterUser(user);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}