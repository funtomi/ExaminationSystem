using ExaminationHelper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1 {
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“Service1”。
    public class Service1 : IService1 {
        private static string SQL_CON = ConfigurationManager.AppSettings["sqlCon"];
        public CompositeType GetDataUsingDataContract(CompositeType composite) {
            if (composite == null) {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue) {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public bool UserLogin(string name, string password, out string errText) {
            errText = "";
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password)) {
                errText = "用户名或密码不能为空！";
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from UserInfo where Name=@Name and Password = @Password";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Password", password);
                    var num = cmd.ExecuteScalar();
                    if (num != null) {
                        return true;
                    }
                    errText = "用户名或密码错误，请检查！";
                    return false;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return false;
            }

        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public bool RegisterUser(string name, string password, out string errText) {
            errText = "";
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password)) {
                errText = "用户名或密码不能为空！";
                return false;
            }
            if (!CheckUserName(name)) {
                errText = "用户名已存在！";
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "insert into UserInfo (Name,Password,Id) values(@Name,@Password,@Id)";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name",name);
                    cmd.Parameters.AddWithValue("@Password",password);
                    cmd.Parameters.AddWithValue("@Id",Guid.NewGuid());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return false;
            }
        }
        /// <summary>
        /// 检查是否有重复用户名
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private bool CheckUserName(string name) {
            if (string.IsNullOrEmpty(name)) {
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select * from UserInfo where Name = @Name";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    var obj = cmd.ExecuteScalar();
                    if (obj == null) {
                        return true;
                    }
                    return false;
                }
            } catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// 获取题目类型
        /// </summary>
        /// <returns></returns>
        public List<string> GetSubjectTypes() {
            try {
                using (SqlConnection conn = new SqlConnection (SQL_CON)) {
                    conn.Open();
                    var sql = "select DisplayName from SubjectType";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    var list = dt.AsEnumerable().Select(p=>p.Field<string>("DisplayName").ToString()).ToList<string>() as List<string>;
                    conn.Close();
                    return list;
                }
            } catch (Exception) {
                return null;
            }
        }

        /// <summary>
        /// 获取题目等级
        /// </summary>
        /// <returns></returns>
        public List<string> GetSubjectLevels() {
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select DisplayName from SubjectLevel";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    var list = dt.AsEnumerable().Select(p => p.Field<string>("DisplayName").ToString()).ToList<string>() as List<string>;
                    conn.Close();
                    return list;
                }
            } catch (Exception) {
                return null;
            }
        }
    }
}
