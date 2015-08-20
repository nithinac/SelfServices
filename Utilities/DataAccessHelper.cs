using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using Oracle.DataAccess.Client;
using SelfServices.Models;

namespace SelfServices.Utilities
{
    public static class DataAccessHelper
    {
        private static string CONNECTION_STRING = ConfigurationManager.ConnectionStrings["oracleXE"].ConnectionString;

        private static string PROFILE_PULL_URL = "";

        private static string BILL_PULL_URL = "";

        private static string BILL_PAY_URL = "";


        public static bool IsUserExists(User user)
        {
            bool exists = false;
            if(user!= null)
            {
                try
                {
                    using (OracleConnection connection = new OracleConnection(CONNECTION_STRING))
                    {
                        OracleCommand command = new OracleCommand();
                        command.CommandText = "SELECT COUNT(*) FROM Users WHERE username LIKE :username AND password LIKE :password";
                        command.Parameters.Add(":username", OracleDbType.NVarchar2).Value = user.Username;
                        command.Parameters.Add(":password", OracleDbType.NVarchar2).Value = user.Password;
                        command.Connection = connection;
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        if (count == 1)
                            exists= true;
                        else
                            exists= false;
                    }
                }

                catch (Exception e)
                {
                    exists = false;
                    Logger.LogException(e);                    
                }
            }
            return exists;                        
        }


        public static bool IsAvailable(string columnName, string value)
        {
            bool available = false;
            if (!String.IsNullOrWhiteSpace(columnName) && value != null)
            {
                try
                {
                    using (OracleConnection connection = new OracleConnection(CONNECTION_STRING))
                    {
                        OracleCommand command = new OracleCommand();
                        command.CommandText = String.Format("SELECT COUNT(*) FROM Users WHERE {0} LIKE :value",columnName);
                        command.Parameters.Add(":value", OracleDbType.NVarchar2).Value = value;
                        command.Connection = connection;
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());                         
                        if (count==0)
                            available = true;
                        else
                            available = false;
                    }
                }

                catch (Exception e)
                {
                    available = false;
                    Logger.LogException(e);
                }
            }
            return available;
        }

        public static bool IsUserNameAvailable(string username)
        {
            return IsAvailable("username", username);                 
        }

        public static bool IsCustomerIdAvailable(string customerId)
        {
            return IsAvailable("customerId", customerId);
        }

        public static void RegisterUser(User user)
        {
            if (user != null)
            {
                try
                {
                    using (OracleConnection connection = new OracleConnection(CONNECTION_STRING))
                    {
                        OracleCommand command = new OracleCommand();
                        command.CommandText = "INSERT INTO Users VALUES(:username,:password,:customerId,:securityQuestion,:securityAnswer)";
                        command.Parameters.Add(":username", OracleDbType.NVarchar2).Value = user.Username;
                        command.Parameters.Add(":password", OracleDbType.NVarchar2).Value = user.Password;
                        command.Parameters.Add(":customerId", OracleDbType.NVarchar2).Value = user.CustomerId;
                        command.Parameters.Add(":securityQuestion", OracleDbType.NVarchar2).Value = user.SecurityQuestion;
                        command.Parameters.Add(":securityAnswer", OracleDbType.NVarchar2).Value = user.SecurtiyAnswer;
                        command.Connection = connection;
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }

                catch (Exception e)
                {                    
                    Logger.LogException(e);
                }
            }
        }

    }
}