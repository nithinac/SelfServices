using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SelfServices.Models
{
    public class ServiceWrapper
    {
        public string Name { get; set; }
    }

    public class OrderWrapper
    {
        public string Id { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime InstallationDate { get; set; }
        public string Status { get; set; }
        public List<ServiceWrapper> Services { get; set; }
    }

    public class Profile
    {
        public List<OrderWrapper> Orders
        {
            get;
            set;
        }

        public string ServiceAddress { get; set; }
    }
    
}