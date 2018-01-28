using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Models.Ext;

namespace DAL
{
    public class ScoreListService
    {
        /// <summary>
        /// Query Grade based on Class Name
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<StudentExt> GetScoreList(string className) {
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ClassName",className)
            };
            SqlDataReader objReader = SQLHelper.GetReader("usp_QueryScroe", param, true);
            List<StudentExt> stuScoreList = new List<StudentExt>();
            while (objReader.Read()) {
                stuScoreList.Add(new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    ClassName = objReader["ClassName"].ToString(),
                    CSharp = objReader["CSharp"].ToString(),
                    SQLServerDB = objReader["SQLServerDB"].ToString() 
                });
            }
            objReader.Close();
            return stuScoreList;
        }
    }
}
