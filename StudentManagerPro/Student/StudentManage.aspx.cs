using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using DAL;


namespace StudentManagerPro.Students
{
    public partial class StudentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.ddlClass.DataSource = new StudentClassService().GetAllClass();
                this.ddlClass.DataTextField = "ClassName";
                this.ddlClass.DataValueField = "ClassId";
                this.ddlClass.DataBind();
            }

            this.ltaMsg.Text = "";
        }

        //Query Students
        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.dlStuInfo.DataSource = new StudentService().GetStudentByClass(this.ddlClass.SelectedItem.Text.Trim());
            this.dlStuInfo.DataBind();
        }

        //Delete Students
        protected void btnDel_Click(object sender, EventArgs e)
        {
            LinkButton lbtn = (LinkButton)sender;
            string studentId = ((LinkButton)sender).CommandArgument;
            try
            {
                int result = new StudentService().DeleteStudentById(studentId);
                if (result == 1) {
                    File.Delete(Server.MapPath("~/Images/Student/" + studentId + ".jpg"));
                    btnQuery_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = " < script type = 'text/javascript' > alert('" + ex.Message + "') </ script > ";
            }
        }
    }
}