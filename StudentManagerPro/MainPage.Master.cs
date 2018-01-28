using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;


namespace StudentManagerPro
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CurrentUser"] == null)
            {
                Response.Redirect("~/AdminLogin.aspx");
            }
            else
            {//If user login successfully it will display user information
                SysAdmin objAdmin = (SysAdmin)Session["CurrentUser"];
                this.ltaUserName.Text = "Welcome back: " + objAdmin.AdminName;
            }
        }
    }
}