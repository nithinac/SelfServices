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
            ViewState["error"] = "";
            if(Request.Form.Count!=0)
            {
                User user = new Models.User(Request.Form["username"], Request.Form["password"], Request.Form["customerId"], Request.Form["secQuestion"], Request.Form["secAnswer"]);
                if(Models.User.TryRegister(user))
                {
                    Response.Redirect("/Pages/Login.aspx");
                }
                else
                {
                    ViewState["error"] = "Customer Id/Username already registered";
                }
            }
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