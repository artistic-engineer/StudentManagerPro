using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using Models;

namespace DAL
{
    public class AdminService
    {
        public SysAdmin AdminLogin(SysAdmin objAdmin) {
            string sql = "select AdminName from Admins where loginId=@LoginId and loginPwd=@LoginPwd";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LoginId",objAdmin.LoginId),
                new SqlParameter("@LoginPwd",objAdmin.LoginPwd)
            };
            try
            {
                SqlDataReader objReader = SQLHelper.GetReader(sql, param, false);
                if (objReader.Read())
                {
                    objAdmin.AdminName = objReader["AdminName"].ToString();
                }
                else {
                    objAdmin = null;
                }
                objReader.Close();
            }
            catch(Exception ex) {
                throw new Exception("Exception"+ex.Message);
            }
            return objAdmin;
        }

        public int ModifyPwd(SysAdmin objAdmin) {
            string sql = "update Admins set LoginPwd = @LoginPwd where LoginId = @LoginId";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@LoginPwd",objAdmin.LoginPwd),
                new SqlParameter("@LoginId",objAdmin.LoginId)
            };
            return SQLHelper.Update(sql, param, false);
        }
    }
}
