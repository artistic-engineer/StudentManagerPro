using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Models;

namespace StudentManagerPro.Students
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                //Initialize class Dropdown box
                this.ddlClass.DataSource = new StudentClassService().GetAllClass();
                this.ddlClass.DataTextField = "ClassName";//Set text in Dropdown box
                this.ddlClass.DataValueField = "ClassId";//Set the text maching value (this value is hidden)
                this.ddlClass.DataBind();//Use data bind method
            }

            this.ltaMsg.Text = "";
        }

        protected void btnAddStudent_Click(object sender, EventArgs e)
        {
            //[1]Judge whether validation code is right
            if (this.txtValidateCode.Text.Trim() != Session["CheckCode"].ToString()) {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('Validation code is wrong')</script>";
                return;
            }
            //[2]Judge whether ID exists
            StudentService objStuService = new StudentService();
            if (objStuService.isIDNoExisted(this.txtStuIdNo.Text.Trim())) {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('ID is already exsiting')</script>";
                return;
            }
            //[3]Encapsulate student object
            Student objStudent = new Student()
            {
                StudentName = this.txtStuName.Text.Trim(),
                Gender = this.ddlGender.Text.Trim(),
                Birthday = Convert.ToDateTime(this.txtStuBirthday.Text.Trim()),
                ClassId = Convert.ToInt32(this.ddlClass.SelectedValue),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtStuAddress.Text.Trim(),
                StudentIdNo = this.txtStuIdNo.Text.Trim(),
            };
            //[4]Save Student object
            try
            {
                int newStudentId = objStuService.AddStudent(objStudent);//Return new student id
                if (newStudentId > 0) {
                    Response.Redirect("~/Student/UpLoadImage.aspx?id=" + newStudentId);
                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = "<script type='text/javascript'>alert('"+ex.Message+"')</script>";
            }
        }
    }
}