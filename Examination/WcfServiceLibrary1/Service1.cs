using ExaminationEntity;
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
        public bool UserLogin(string name, string password, out string errText,out Guid userId) {
            errText = "";
            userId = Guid.Empty;
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password)) {
                errText = "用户名或密码不能为空！";
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select Id from UserInfo where Name=@Name and Password = @Password";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Password", password);
                    var id = cmd.ExecuteScalar().ToString();
                    if (string.IsNullOrEmpty(id)) {
                        userId = Guid.Parse(id);
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

        /// <summary>
        /// 获取随机题目
        /// </summary>
        /// <param name="num"></param>
        /// <param name="level"></param>
        /// <param name="type"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public List<SubjectInfo> GetSubjects(int num, string level, string type,out string errText) {
            errText = "";
            if (num<0||string.IsNullOrEmpty(level)||string.IsNullOrEmpty(type)) {
                errText = "获取考试题目失败，请重新选择考试！";
                return null;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "select top " + num.ToString() + " * from Subject where SubLevel=@SubLevel order by NEWID() ";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    if (type != "混合") {
                        cmd.CommandText = "select top " + num.ToString() + " * from Subject where SubLevel=@SubLevel and SubType=@SubType  order by NEWID()";
                       cmd.Parameters.AddWithValue("@SubType", type);
                    }
                    cmd.Parameters.AddWithValue("@SubLevel",level);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    var list = DataTableHelper.DataTableToList<SubjectInfo>(dt) as List<SubjectInfo>;
                    conn.Close();
                    return list;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// 保存成绩
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="score"></param>
        /// <param name="subNum"></param>
        /// <param name="subLevel"></param>
        /// <param name="errText"></param>
        /// <returns></returns>
        public bool SaveScore(Guid id, string name, int score, int subNum, string subLevel,out string errText) {
            errText = "";
            if (id==null||string.IsNullOrEmpty(name)) {
                errText = "找不到目标用户！";
                return false;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    conn.Open();
                    var sql = "declare @HighestScore int "
                          + "set @HighestScore = (select MAX(Record)  from UserRecord where UserId=@UserId) "
                        + "insert into UserRecord (Id,UserId,Name,Record,TestTime,SubjectNum,SubjectLevel,TestTimes,HighestScore)" +
                            "values(@Id,@UserId,@Name,@Record,SYSDATETIME(),@SubjectNum,@SubjectLevel," +
                              "(select COUNT(Name) from UserRecord where UserId=@UserId)+1," +
                        "(select num=case when @HighestScore>=@Record then @HighestScore when @HighestScore<@Record then @Record else @Record end ))";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@Id", Guid.NewGuid());
                    cmd.Parameters.AddWithValue("@UserId", id);
                    cmd.Parameters.AddWithValue("Name", name);
                    cmd.Parameters.AddWithValue("@Record", score);
                    cmd.Parameters.AddWithValue("SubjectNum", subNum);
                    cmd.Parameters.AddWithValue("@SubjectLevel", subLevel);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    return true;
                }
            } catch (Exception ex) {
                errText = ex.Message;
                return false;
            }
        }

        public DataTable GetStudyData(Guid id, string name, DateTime start, DateTime end, out string errText) {
            errText = "";
            if (id == null || id == Guid.Empty || string.IsNullOrEmpty(name)) {
                errText = "用户信息不可为空！";
                return null;
            }
            if (start > end) {
                errText = "开始时间不能大于结束时间！";
                return null;
            }
            try {
                using (SqlConnection conn = new SqlConnection(SQL_CON)) {
                    var sql = "select Record,TestTime,HighestScore from UserRecord where UserId=@Id and Name=@Name and TestTime >=@StartDate and TestTime<=@EndDate";
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("Name", name);
                    cmd.Parameters.AddWithValue("Id", id);
                    cmd.Parameters.AddWithValue("StartDate", start);
                    cmd.Parameters.AddWithValue("EndDate", end);
                    SqlDataAdapter ada = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    ada.Fill(dt);
                    return dt;
                }

            } catch (Exception ex) {
                errText = ex.Message;
                return null;
            }
        }
    }
}
