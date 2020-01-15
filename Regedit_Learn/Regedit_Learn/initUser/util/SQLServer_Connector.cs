using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace Regedit_Learn {
    class SQLServer_Connector {
        string _connString = "server=178.20.10.85;database=Net2Dynetmanage2019;uid=sa;pwd=lq612176()";

        public SQLServer_Connector(string connStr) {
            _connString = connStr;
        }

        #region 打开数据库
        /// <summary>
        /// 打开数据库
        /// </summary>
        /// <returns></returns>
        public bool OpenDataBase() {
            try {
                //创建数据库连接对象
                using (SqlConnection sqlConn = new SqlConnection(_connString)) {
                    //打开连接
                    sqlConn.Open();
                    sqlConn.Close();
                    return true;
                }
            }
            catch {
                return false;
            }
        }
        #endregion

        #region 查找
        public void query() {
            //后面拼写查询语句要用到窗体的信息
            string user = "陈济扬";//获取用户名
            //string pwd = textBox2.Text;//获取密码
            User a = null;
            //创建数据库连接类的对象
            SqlConnection con = new SqlConnection(_connString);
            //将连接打开
            con.Open();
            //执行con对象的函数，返回一个SqlCommand类型的对象
            SqlCommand cmd = con.CreateCommand();
            //把输入的数据拼接成sql语句，并交给cmd对象
            //cmd.CommandText = "select*from users where name='" + user + "'and pwd='" + pwd + "'";
            cmd.CommandText = "select * from UserInfo where strName='" + user + "'";

            //用cmd的函数执行语句，返回SqlDataReader对象dr,dr就是返回的结果集（也就是数据库中查询到的表数据）
            SqlDataReader dr = cmd.ExecuteReader();
            var jsonStr = toJSONStr(dr);
            var jsonObj = JsonConvert.DeserializeObject<Object>(jsonStr);
            //用dr的read函数，每执行一次，返回一个包含下一行数据的集合dr，在执行read函数之前，dr并不是集合
            if (dr.Read()) {
                a.code = dr[0].ToString();
                a.name = dr[1].ToString();
                a.password = dr[2].ToString();
                //label4.Text = "用户名" + a.name + "密码" + a.password;
                //dr[]里面可以填列名或者索引，显示获得的数据
                // MessageBox.Show("当前用户信息存在"+dr[1].ToString() + dr[2].ToString());
                //  MessageBox.Show("当前用户信息" + a.name + a.password);
            }
            else {
                MessageBox.Show("当前用户信息不存在");
            }
            //用完后关闭连接，以免影响其他程序访问
            con.Close();
        }
        #endregion

        #region 添加数据
        //public void add() {
        //    string MyConn = "server=127.0.0.1;uid=user;pwd=123456;database=Northwind;Trusted_Connection=no";
        //    SqlConnection MyConnection = new SqlConnection(MyConn);
        //    string MyInsert = "insert into Categories(CategoryName, Description)values('" + Convert.ToString(TextBox2.Text) + "','" + Convert.ToString(TextBox3.Text) + "')";
        //    SqlCommand MyCommand = new SqlCommand(MyInsert, MyConnection);
        //    try//异常处理
        //    {
        //        MyConnection.Open();
        //        MyCommand.ExecuteNonQuery();
        //        MyConnection.Close();
        //    }
        //    catch (Exception ex) {
        //        Console.WriteLine("{0} Exception caught.", ex);
        //    }
        //}
        #endregion

        #region 修改数据
        //public void update() {
        //    string categoryName = TextBox2.Text;
        //    string categoryDescription = TextBox3.Text;
        //    string MyConn = "server=127.0.0.1;uid=user;pwd=123456;database=Northwind;Trusted_Connection=no";
        //    SqlConnection MyConnection = new SqlConnection(MyConn);
        //    string MyUpdate = "Update Categories set CategoryName='" + categoryName + "',Description='" + categoryDescription + "' where CategoryID=" + TextBox1.Text;
        //    SqlCommand MyCommand = new SqlCommand(MyUpdate, MyConnection);
        //    try {
        //        MyConnection.Open();
        //        MyCommand.ExecuteNonQuery();
        //        MyConnection.Close();
        //        TextBox1.Text = "";
        //    }
        //    catch (Exception ex) {
        //        Console.WriteLine("{0} Exception caught.", ex);
        //    }
        //}
        #endregion

        #region 删除数据
        //public void delete() {
        //    string MyConn = "server=127.0.0.1;uid=user;pwd=123456;database=Northwind;Trusted_Connection=no";
        //    SqlConnection MyConnection = new SqlConnection(MyConn);
        //    string MyDelete = "Delete from Categories where CategoryID=" + TextBox1.Text;
        //    SqlCommand MyCommand = new SqlCommand(MyDelete, MyConnection);
        //    try {
        //        MyConnection.Open();
        //        MyCommand.ExecuteNonQuery();
        //        MyConnection.Close();
        //        TextBox1.Text = "";
        //    }
        //    catch (Exception ex) {
        //        Console.WriteLine("{0} Exception caught.", ex);
        //    }
        //}
        #endregion

        public string toJSONStr(SqlDataReader o) {
            StringBuilder s = new StringBuilder();
            //s.Append("[");
            if (o.HasRows)
                while (o.Read())
                    s.Append("{" + '"' + "strUserID" + '"' + ":" + '"' + o["strUserID"] + '"' + ", "
                    + '"' + "strWorkCode" + '"' + ":" + '"' + o["strWorkCode"] + '"' + ", "
                    + '"' + "strName" + '"' + ":" + '"' + o["strName"] + '"' + ","
                    + '"' + "strPassword" + '"' + ":" + '"' + o["strPassword"] + '"' + ","
                    + '"' + "dwOrigin" + '"' + ":" + o["dwOrigin"] + ","
                    + '"' + "strMobilePhone" + '"' + ":" + '"' + o["strMobilePhone"] + '"' + ","
                    + '"' + "strTelephone" + '"' + ":" + '"' + o["strTelephone"] + '"' + ","
                    + '"' + "strEmailAddress" + '"' + ":" + '"' + o["strEmailAddress"] + '"' + ","
                    + '"' + "dwVerifyMode" + '"' + ":" + o["dwVerifyMode"] + ","
                    + '"' + "pbIcon" + '"' + ":" + '"' + o["pbIcon"] + '"' + ","
                    + '"' + "enumUserStatus" + '"' + ":" + o["enumUserStatus"] + ","
                    + '"' + "odtUpdateDate" + '"' + ":" + '"' + o["odtUpdateDate"] + '"' + ","
                     + '"' + "odtCreateDate" + '"' + ":" + '"' + o["odtCreateDate"] + '"' + ","
                      + '"' + "strHint" + '"' + ":" + '"' + o["strHint"] + '"' + ","
                       + '"' + "strAttriReserved1" + '"' + ":" + '"' + o["strAttriReserved1"] + '"' + ","
                        + '"' + "strAttriReserved2" + '"' + ":" + '"' + o["strAttriReserved2"] + '"' + ","
                        + '"' + "strAttriReserved3" + '"' + ":" + '"' + o["strAttriReserved3"] + '"' + ","
                        + '"' + "strAttriReserved4" + '"' + ":" + '"' + o["strAttriReserved4"] + '"' + ","
                        + '"' + "strAttriReserved5" + '"' + ":" + '"' + o["strAttriReserved5"] + '"' + ","
                        + '"' + "strAttriReserved6" + '"' + ":" + '"' + o["strAttriReserved6"] + '"' + ","
                        + '"' + "strAttriReserved7" + '"' + ":" + '"' + o["strAttriReserved7"] + '"' + ","
                        + '"' + "strAttriReserved8" + '"' + ":" + '"' + o["strAttriReserved8"] + '"' + ","
                    + '"' + "strAttriReserved9" + '"' + ":" + '"' + o["strAttriReserved9"] + '"' + "}, ");
            s.Remove(s.Length - 2, 2);
            //s.Append("]");
            o.Close();
            return s.ToString();
        }
    }
}