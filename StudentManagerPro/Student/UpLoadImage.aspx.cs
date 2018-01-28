using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentManagerPro.Students
{
    public partial class UpLoadImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                if (Request.QueryString["Id"] == null) {
                    Response.Redirect("~/ErrorPage.html");
                }
                ViewState["StudentId"] = Request.QueryString["id"];
            }
            this.ltaMsg.Text = "";
          
        }
        //Upload photos
        protected void btnUpLoadImage_Click(object sender, EventArgs e)
        {
            //Check whether possess file
            if (!this.fulStuImage.HasFile) return;
            //Get file size and check whether its size satisfy user's request
            double fileLength = this.fulStuImage.FileContent.Length / (1024 * 1024);
            if (fileLength > 30) {
                this.ltaMsg.Text = "<script>alert('Image size can't exceed 30M')</script>";
                return;
            }
            //Get file name and standardize it
            string fileName = this.fulStuImage.FileName;
            if (fileName.Substring(fileName.LastIndexOf(".")).ToLower() != ".jpg") {
                this.ltaMsg.Text = "<script>alert('Photo must be jpg type!')</script>";
                return;
            }
            fileName = ViewState["StudentId"].ToString() + ".jpg";
            //Upload file
            try
            {
                string path = Server.MapPath("~/Images/Student");
                this.fulStuImage.SaveAs(path + "/" + fileName);

                if (Request.QueryString["IsModify"] == "1")
                {
                    this.ltaMsg.Text = "<script>alert('Modify successfully');location='StudentManage.aspx'</script>";
                }
                else {
                    this.ltaMsg.Text = "<script>alert('Success');location = 'AddStudent.aspx'</script>";
                }
            }
            catch (Exception ex) {
                this.ltaMsg.Text = "<script>alert('Upload failed" + ex.Message + "')</script>";
            }

        }
        
    }
}