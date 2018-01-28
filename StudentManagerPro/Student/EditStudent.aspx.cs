using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Models;
using Models.Ext;


namespace StudentManagerPro.Students
{
    public partial class EditStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Display class dropbox
                this.ddlClass.DataSource = new StudentClassService().GetAllClass();
                this.ddlClass.DataTextField = "ClassName";
                this.ddlClass.DataValueField = "ClassId";
                this.ddlClass.DataBind();

                //Display student information based on ID 
                string studentId = Request.QueryString["StudentId"];
                if (studentId == null)
                {
                    Response.Redirect("~/ErrorPage.html");
                }
                else
                {
                    StudentExt objStudent = new StudentService().GetStudentById(studentId);
                    if (objStudent != null)
                    {
                        this.ltaStudentId.Text = objStudent.StudentId.ToString();
                        this.txtStuName.Text = objStudent.StudentName;
                        this.txtStuIdNo.Text = objStudent.StudentIdNo;
                        this.txtPhoneNumber.Text = objStudent.PhoneNumber;
                        this.txtStuAddress.Text = objStudent.StudentAddress;
                        this.ddlClass.SelectedValue = objStudent.ClassId.ToString();//Binding class
                        this.ddlGender.Text = objStudent.Gender;
                        this.txtStuBirthday.Text = objStudent.Birthday.ToString("yyyy-MM-dd");
                    }
                    else
                    {
                        Response.Redirect("~/ErrorPage.html");
                    }
                }
            } 
        }

        protected void btnEditStudent_Click(object sender, EventArgs e)
        {
            StudentService objStuService = new StudentService();
            if (objStuService.IsIDNoExisted(this.txtStuIdNo.Text.Trim(), this.ltaStudentId.Text)) {
                this.ltaMsg.Text = " < script type = 'text/javascript' > alert('ID is already exsiting') </ script > ";
                return;
            }
            Student objStudent = new Student()
            {
                StudentName = this.txtStuName.Text.Trim(),
                Gender = this.ddlGender.Text.Trim(),
                Birthday = Convert.ToDateTime(this.txtStuBirthday.Text.Trim()),
                ClassId = Convert.ToInt32(this.ddlClass.SelectedValue),
                PhoneNumber = this.txtPhoneNumber.Text.Trim(),
                StudentAddress = this.txtStuAddress.Text.Trim(),
                StudentIdNo = this.txtStuIdNo.Text.Trim(),
                StudentId = Convert.ToInt32(this.ltaStudentId.Text.Trim())
            };
            //Save in Database
            try
            {
                int result = objStuService.ModifyStudent(objStudent);
                if (result > 0) {
                    Response.Redirect("~/Student/UpLoadImage.aspx?IsModify=1&Id=" + this.ltaStudentId.Text);
                }
            }
            catch (Exception ex)
            {
                this.ltaMsg.Text = " < script type = 'text/javascript' > alert('"+ex.Message+"') </ script > ";
            } 
        }
    }
}