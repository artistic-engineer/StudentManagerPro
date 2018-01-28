using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Models.Ext;


namespace StudentManagerPro.Students
{
    public partial class StudentDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                string studentId = Request.QueryString["StudentId"];
                StudentExt objStudent = new StudentService().GetStudentById(studentId);

                this.ltaStudentId.Text = objStudent.StudentId.ToString();
                this.ltaStudentName.Text = objStudent.StudentName;
                this.ltaStudentIdNo.Text = objStudent.StudentIdNo;
                this.ltaPhoneNumber.Text = objStudent.PhoneNumber;
                this.ltaAddress.Text = objStudent.StudentAddress;
                this.ltaClass.Text = objStudent.ClassName;//Binding class
                this.ltaGender.Text = objStudent.Gender;
                this.ltaBirthday.Text = objStudent.Birthday.ToString("yyyy-MM-dd");
                this.stuImg.ImageUrl = "~/images/Student/" + objStudent.StudentId + ".jpg";
            }
        }
    }
}