using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DAL;
using Models;


namespace StudentManagerPro.Score
{
    public partial class ScoreManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.ddlClass.DataSource = new StudentClassService().GetAllClass();
                this.ddlClass.DataTextField = "ClassName";
                this.ddlClass.DataValueField = "ClassId";
                this.ddlClass.DataBind();
            }
        }

        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.GridView1.DataSource = new ScoreListService().GetScoreList(this.ddlClass.SelectedItem.Text);
            this.GridView1.DataBind();
        }
    }
}