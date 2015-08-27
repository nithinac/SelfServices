using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SelfServices.Utilities;

namespace SelfServices.Models
{

    public class Bill
    {
        public string Name { get; set; }
        public string PrimaryPhone { get; set; }
        public string Address { get; set; }
        public string AccountNumber { get; set; }
        public string BillDate { get; set; }
        public Account_Summary Account_Summary { get; set; }
        public string taxes { get; set; }
        public string totalAmount { get; set; }

        public static Bill GetUserBill(string customerId)
        {
            return ServiceJsonHelper.GetBill(customerId);
        }

        public static bool IsBillPaid(string customerId, string date)
        {
            return DataAccessHelper.IsBillPaid(customerId, date);
        }
    }

    public class Account_Summary
    {
        public Previous_Period Previous_Period { get; set; }
        public Currentcharges CurrentCharges { get; set; }
        public Additionalcharges AdditionalCharges { get; set; }
    }

    public class Previous_Period
    {
        public string PreviousBalance { get; set; }
        public string PaymentReceived { get; set; }
        public string BalanceForward { get; set; }
    }

    public class Currentcharges
    {
        public Service[] Services { get; set; }
        public string subtotal { get; set; }
    }

    public class Service
    {
        public string name { get; set; }
        public string price { get; set; }
    }

    public class Additionalcharges
    {
        public Additionalservice[] AdditionalServices { get; set; }
        public string subtotal { get; set; }
    }

    public class Additionalservice
    {
        public string name { get; set; }
        public string price { get; set; }
    }



}