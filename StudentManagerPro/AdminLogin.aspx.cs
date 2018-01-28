using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Models;
using DAL;


namespace StudentManagerPro
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            //[1]Ecapusilate login information
            SysAdmin objAdmin = new SysAdmin()
            {
                LoginId = Convert.ToInt32(this.txtUserId.Text.Trim()),
                LoginPwd = this.txtPwd.Text.Trim()
            };
            //[2]Using Data Accessing class to query user information
            try
            {
                objAdmin = new AdminService().AdminLogin(objAdmin);
                if (objAdmin == null)
                {
                    this.ltaInfo.Text = "<script>alert('User name or password is wrong')</script>";
                }
                else {
                    Session["CurrentUser"] = objAdmin;
                    Response.Redirect("~/Default.aspx",false);
                }
            }
            catch (Exception ex)
            {
                this.ltaInfo.Text = "<script>alert('"+ex.Message+"')</script>";
            }
        }
    }
}