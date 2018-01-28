using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using Models;
using Models.Ext;

namespace DAL
{
    public class StudentService
    {
        /// <summary>
        /// Decide whether student id exists
        /// </summary>
        /// <param name="studentIdNo"></param>
        /// <returns></returns>
        public bool isIDNoExisted(string studentIdNo) {
            string sql = "select count(*) from Students where StudentIdNo=@StudentIdNo";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@StudentIdNo",studentIdNo)
            };
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, param, false));
            if (result == 1) return true;
            else return false;
        }

        #region Add Students
        public int AddStudent(Student objStudent) {
            //[1] Encapsulate
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@StudentName",objStudent.StudentName),
                new SqlParameter("@Gender",objStudent.Gender),
                new SqlParameter("@StudentIdNo",objStudent.StudentIdNo),
                new SqlParameter("@Birthday",objStudent.Birthday),
                new SqlParameter("@PhoneNumber",objStudent.PhoneNumber),
                new SqlParameter("@StudentAddress",objStudent.StudentAddress),
                new SqlParameter("@ClassId",objStudent.ClassId),
            };
            //[2]Use procedure
            return Convert.ToInt32(SQLHelper.GetSingleResult("usp_AddStudent", param, true));
        }
        #endregion

        #region Query Students
        public List<StudentExt> GetStudentByClass(string className) {
            string sql = "select StudentId,StudentName,Gender,Birthday,ClassName,StudentAddress from Students";
            sql += " inner join StudentClass on Students.ClassId = StudentClass.ClassId";
            sql += " where ClassName = @ClassName";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@ClassName",className)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sql, param, false);
            List<StudentExt> stuList = new List<StudentExt>();
            while (objReader.Read()) {
                stuList.Add(new StudentExt() {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    StudentAddress = objReader["StudentAddress"].ToString()
                });
            }
            objReader.Close();
            return stuList;
        }

        public StudentExt GetStudentById(string studentId) {
            StringBuilder sqlBuilder = new StringBuilder();
            sqlBuilder.Append("select StudentId,StudentName,Gender,Birthday,ClassName, ");
            sqlBuilder.Append("StudentIdNo,PhoneNumber,StudentAddress,Students.ClassId from Students ");
            sqlBuilder.Append("inner join StudentClass on Students.ClassId = StudentClass.ClassId");
            sqlBuilder.Append(" where StudentId = @StudentId");
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@StudentId",studentId)
            };
            SqlDataReader objReader = SQLHelper.GetReader(sqlBuilder.ToString(), param, false);
            StudentExt objStudent = null;
            if (objReader.Read()) {
                objStudent = new StudentExt()
                {
                    StudentId = Convert.ToInt32(objReader["StudentId"]),
                    StudentName = objReader["StudentName"].ToString(),
                    Gender = objReader["Gender"].ToString(),
                    Birthday = Convert.ToDateTime(objReader["Birthday"]),
                    ClassName = objReader["ClassName"].ToString(),
                    StudentIdNo = objReader["StudentIdNo"].ToString(),
                    PhoneNumber = objReader["PhoneNumber"].ToString(),
                    ClassId = Convert.ToInt32(objReader["ClassId"]),
                    StudentAddress = objReader["StudentAddress"].ToString()
                };
            }
            objReader.Close();
            return objStudent;
        }
        #endregion

        #region Modify Students
        public bool IsIDNoExisted(string idNo, string studentId) {
            string sql = "select count(*) from Students where StudentIdNo = @StudentIdNo and StudentId<> @StudentId";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@StudentIdNo",idNo),
                new SqlParameter("@StudentId",studentId)
            };
            int result = Convert.ToInt32(SQLHelper.GetSingleResult(sql, param, false));
            if (result == 1) return true;
            else return false; 
        }

        public int ModifyStudent(Student objStudent) {
            //[1] Encapsulate
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@StudentName",objStudent.StudentName),
                new SqlParameter("@Gender",objStudent.Gender),
                new SqlParameter("@StudentIdNo",objStudent.StudentIdNo),
                new SqlParameter("@Birthday",objStudent.Birthday),
                new SqlParameter("@PhoneNumber",objStudent.PhoneNumber),
                new SqlParameter("@StudentAddress",objStudent.StudentAddress),
                new SqlParameter("@ClassId",objStudent.ClassId),
                new SqlParameter("@StudentId",objStudent.StudentId)
            };
            //[2]Use procedure
            return Convert.ToInt32(SQLHelper.Update("usp_ModifyStudent", param, true));
        }


        #endregion

        #region Delete Students

        public int DeleteStudentById(string studentId) {
            string sql = "delete from Students where StudentId=@StudentId ";
            SqlParameter[] param = new SqlParameter[] {
                new SqlParameter("@StudentId",studentId)
            };
            try
            {
                return SQLHelper.Update(sql, param, false);
            }
            catch (SqlException ex) {
                if (ex.Number == 547)
                {
                    throw new Exception("You cannot delete it directly");
                }
                else {
                    throw new Exception("Database Exception"+ex.Message);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Database Exception" + ex.Message);
            }
        }
        #endregion
    }
}
