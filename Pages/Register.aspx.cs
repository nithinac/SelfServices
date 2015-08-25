using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using SelfServices.Models;

namespace SelfServices.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (Request.Form.Count != 0)
            {
                User user = new Models.User(Request.Form["username"], Request.Form["password"], Request.Form["customerId"], Request.Form["securityQuestion"], Request.Form["securityAnswer"], Request.Form["email"]);
                if (Models.User.TryRegister(user))
                {
                    Session.Add("customerId", user.CustomerId);
                    Response.Redirect("/Pages/OrderStatus.aspx");
                }
                else
                {
                    Response.Redirect("/Pages/Index.aspx?tab=register&error=true");
                }
            }
            else
                Response.Redirect("/Pages/Index.aspx");
        }

        //[WebMethod]
        //public string CheckAvailability(string customerId, string username, string password, string securityQuestion, string securityAnswer)
        //{
        //    User user = new User(username, password, customerId, securityQuestion, securityAnswer);
        //    if (Models.User.TryRegister(user))
        //    {
        //        return "/Pages/Login.aspx";
        //    }
        //    else
        //    {
        //        return "error";
        //    }
        //}
    }
}