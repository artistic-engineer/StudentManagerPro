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
    public partial class ChangePwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Session["CurrentUser"] == null) {
                    Response.Redirect("~/AdminLogin.aspx");
                }
            }
        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            //Decide whehter original password is right
            SysAdmin objAdmin = (SysAdmin)Session["CurrentUser"];
            if (objAdmin.LoginPwd != this.txtOldPwd.Text.Trim()) {
                this.ltaMsg.Text = "<script>alert('Original password isn not right')</script>";
                //this.ltaMsg.Text = "<script>alert('hahaha')</script>";
                return;
            }
            //Encapusilate new password
            objAdmin.LoginPwd = this.txtNewPwd.Text.Trim();
            //Use backend method to change password
            try
            {
                new AdminService().ModifyPwd(objAdmin);
                this.ltaMsg.Text = "<script>alert('Password is modified successfully');location='../Default.aspx'</script>";
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script>alert('"+ex.Message+"')";
            }
        }
    }
}